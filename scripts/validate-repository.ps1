$ErrorActionPreference = 'Stop'

$repoRoot = Split-Path -Parent $PSScriptRoot

function ConvertTo-MarkdownAnchorSlug {
  param(
    [Parameter(Mandatory = $true)]
    [string]$Heading
  )

  $slug = $Heading.Trim().ToLowerInvariant()
  $slug = [regex]::Replace($slug, '[`"''.,:;!?()/\[\]{}<>#+=*&^%$@|~]', '')
  $slug = [regex]::Replace($slug, '\s+', '-')
  $slug = [regex]::Replace($slug, '-{2,}', '-')
  return $slug.Trim('-')
}

function Get-MarkdownHeadingAnchors {
  param(
    [Parameter(Mandatory = $true)]
    [string]$FilePath
  )

  $anchors = New-Object System.Collections.Generic.HashSet[string]([System.StringComparer]::OrdinalIgnoreCase)

  foreach ($line in Get-Content -Path $FilePath) {
    if ($line -match '^(#{1,6})\s+(.+?)\s*$') {
      $heading = $matches[2].Trim()
      if ($heading.Length -gt 0) {
        [void]$anchors.Add((ConvertTo-MarkdownAnchorSlug -Heading $heading))
      }
    }
  }

  return $anchors
}

function Get-RepositoryRelativePath {
  param(
    [Parameter(Mandatory = $true)]
    [string]$BasePath,
    [Parameter(Mandatory = $true)]
    [string]$TargetPath
  )

  $basePath = [System.IO.Path]::GetFullPath($BasePath)
  if (-not $basePath.EndsWith([System.IO.Path]::DirectorySeparatorChar) -and -not $basePath.EndsWith([System.IO.Path]::AltDirectorySeparatorChar)) {
    $basePath += [System.IO.Path]::DirectorySeparatorChar
  }

  $baseUri = [System.Uri]$basePath
  $targetUri = [System.Uri]([System.IO.Path]::GetFullPath($TargetPath))
  $relativeUri = $baseUri.MakeRelativeUri($targetUri)
  return [System.Uri]::UnescapeDataString($relativeUri.ToString()).Replace('/', [System.IO.Path]::DirectorySeparatorChar)
}

function Test-MarkdownLinks {
  param(
    [Parameter(Mandatory = $true)]
    [string]$RootPath
  )

  $markdownFiles = Get-ChildItem -Path $RootPath -Filter *.md -Recurse -File |
    Where-Object { $_.FullName -notmatch '[\\/](bin|obj|.git)[\\/]' }

  $anchorCache = @{}
  $errors = New-Object System.Collections.Generic.List[string]

  foreach ($file in $markdownFiles) {
    $inFence = $false
    $lineNumber = 0

    foreach ($line in Get-Content -Path $file.FullName) {
      $lineNumber++

      if ($line -match '^```') {
        $inFence = -not $inFence
        continue
      }

      if ($inFence) {
        continue
      }

      foreach ($match in [regex]::Matches($line, '(?<!!\[)!?\[[^\]]*\]\((?<target>[^)]+)\)')) {
        $target = $match.Groups['target'].Value.Trim()

        if ([string]::IsNullOrWhiteSpace($target)) {
          continue
        }

        if ($target -match '^(https?|mailto|tel):' -or $target.StartsWith('<') -or $target.StartsWith('data:')) {
          continue
        }

        $target = $target.Split(' ')[0].Trim('<>')
        $target = [System.Uri]::UnescapeDataString($target)

        $pathPart = $target
        $anchorPart = $null

        if ($target.Contains('#')) {
          $segments = $target.Split('#', 2)
          $pathPart = $segments[0]
          $anchorPart = $segments[1]
        }

        $resolvedPath = $file.FullName

        if (-not [string]::IsNullOrWhiteSpace($pathPart)) {
          $combinedPath = [System.IO.Path]::GetFullPath((Join-Path $file.DirectoryName $pathPart))
          $resolvedPath = $combinedPath

          if (-not (Test-Path -LiteralPath $resolvedPath)) {
            $relativeFile = Get-RepositoryRelativePath -BasePath $RootPath -TargetPath $file.FullName
            $errors.Add("${relativeFile}:$lineNumber -> missing link target '$target'")
            continue
          }
        }

        if (-not [string]::IsNullOrWhiteSpace($anchorPart)) {
          $normalizedAnchor = $anchorPart.Trim().ToLowerInvariant()

          if (-not $anchorCache.ContainsKey($resolvedPath)) {
            if ([System.IO.Path]::GetExtension($resolvedPath) -ieq '.md') {
              $anchorCache[$resolvedPath] = Get-MarkdownHeadingAnchors -FilePath $resolvedPath
            }
            else {
              $anchorCache[$resolvedPath] = $null
            }
          }

          $availableAnchors = $anchorCache[$resolvedPath]
          if ($null -eq $availableAnchors) {
            $relativeFile = Get-RepositoryRelativePath -BasePath $RootPath -TargetPath $file.FullName
            $errors.Add("${relativeFile}:$lineNumber -> anchor '$anchorPart' points to a non-Markdown target '$target'")
            continue
          }

          if (-not $availableAnchors.Contains($normalizedAnchor)) {
            $relativeFile = Get-RepositoryRelativePath -BasePath $RootPath -TargetPath $file.FullName
            $errors.Add("${relativeFile}:$lineNumber -> missing anchor '$anchorPart' in '$target'")
          }
        }
      }
    }
  }

  if ($errors.Count -gt 0) {
    throw "Markdown link validation failed:`n$($errors -join [Environment]::NewLine)"
  }
}

function Test-CurriculumTopicBundles {
  param(
    [Parameter(Mandatory = $true)]
    [string]$RootPath
  )

  $curriculumRoot = Join-Path $RootPath 'docs/curriculum'
  $requiredTopicFiles = @('README.md', 'lesson.md', 'exercises.md', 'checklist.md')
  $requiredFrontmatterKeys = @('title', 'stage', 'topic', 'level', 'estimated_hours', 'prerequisites', 'learning_outcomes')
  $errors = New-Object System.Collections.Generic.List[string]

  if (-not (Test-Path -LiteralPath $curriculumRoot)) {
    return
  }

  $stageDirectories = Get-ChildItem -Path $curriculumRoot -Directory |
    Where-Object { $_.Name -match '^\d{2}-[a-z0-9-]+$' }

  foreach ($stageDirectory in $stageDirectories) {
    $topicDirectories = Get-ChildItem -Path $stageDirectory.FullName -Directory |
      Where-Object { $_.Name -match '^\d{2}[a-z]?-[a-z0-9-]+$' }

    foreach ($topicDirectory in $topicDirectories) {
      $missingFiles = @(
        $requiredTopicFiles | Where-Object {
          -not (Test-Path -LiteralPath (Join-Path $topicDirectory.FullName $_))
        }
      )

      if ($missingFiles.Count -gt 0) {
        $relativeTopicDirectory = Get-RepositoryRelativePath -BasePath $RootPath -TargetPath $topicDirectory.FullName
        $errors.Add("${relativeTopicDirectory} -> missing required topic files: $($missingFiles -join ', ')")
        continue
      }

      $lessonPath = Join-Path $topicDirectory.FullName 'lesson.md'
      $lessonLines = Get-Content -Path $lessonPath
      $relativeLessonPath = Get-RepositoryRelativePath -BasePath $RootPath -TargetPath $lessonPath

      if ($lessonLines.Count -eq 0 -or $lessonLines[0].Trim() -ne '---') {
        $errors.Add("${relativeLessonPath} -> lesson is missing the opening YAML frontmatter delimiter")
        continue
      }

      $metadataKeys = New-Object System.Collections.Generic.HashSet[string]([System.StringComparer]::OrdinalIgnoreCase)
      $frontmatter = @{}
      $hasClosingDelimiter = $false

      for ($lineIndex = 1; $lineIndex -lt $lessonLines.Count; $lineIndex++) {
        $line = $lessonLines[$lineIndex]

        if ($line.Trim() -eq '---') {
          $hasClosingDelimiter = $true
          break
        }

        if ($line -match '^([a-z_]+):\s*(.*)$') {
          $key = $matches[1]
          $value = $matches[2].Trim()
          [void]$metadataKeys.Add($key)
          $frontmatter[$key] = $value
        }
      }

      if (-not $hasClosingDelimiter) {
        $errors.Add("${relativeLessonPath} -> lesson frontmatter is missing the closing YAML delimiter")
        continue
      }

      $missingKeys = @($requiredFrontmatterKeys | Where-Object { -not $metadataKeys.Contains($_) })
      if ($missingKeys.Count -gt 0) {
        $errors.Add("${relativeLessonPath} -> lesson frontmatter is missing required keys: $($missingKeys -join ', ')")
      }

      if ($frontmatter.ContainsKey('stage') -and $frontmatter['stage'] -ne $stageDirectory.Name) {
        $errors.Add("${relativeLessonPath} -> lesson frontmatter stage '$($frontmatter['stage'])' does not match folder '$($stageDirectory.Name)'")
      }

      if ($frontmatter.ContainsKey('topic') -and $frontmatter['topic'] -ne $topicDirectory.Name) {
        $errors.Add("${relativeLessonPath} -> lesson frontmatter topic '$($frontmatter['topic'])' does not match folder '$($topicDirectory.Name)'")
      }
    }
  }

  if ($errors.Count -gt 0) {
    throw "Curriculum metadata validation failed:`n$($errors -join [Environment]::NewLine)"
  }
}

function Test-SampleDataConventions {
  param(
    [Parameter(Mandatory = $true)]
    [string]$RootPath
  )

  $assetRoots = @(
    (Join-Path $RootPath 'src'),
    (Join-Path $RootPath 'labs'),
    (Join-Path $RootPath 'tests')
  ) | Where-Object { Test-Path -LiteralPath $_ }

  $projectDirectories = New-Object System.Collections.Generic.HashSet[string]([System.StringComparer]::OrdinalIgnoreCase)
  $errors = New-Object System.Collections.Generic.List[string]

  foreach ($project in Get-ChildItem -Path $RootPath -Filter *.csproj -Recurse -File | Where-Object { $_.FullName -notmatch '[\\/](bin|obj)[\\/]' }) {
    [void]$projectDirectories.Add((Split-Path -Path $project.FullName -Parent))
  }

  foreach ($assetRoot in $assetRoots) {
    $dataFiles = Get-ChildItem -Path $assetRoot -Recurse -File |
      Where-Object {
        $_.FullName -notmatch '[\\/](bin|obj)[\\/]' -and $_.Extension -in '.json', '.csv', '.txt'
      }

    foreach ($dataFile in $dataFiles) {
      $relativePath = Get-RepositoryRelativePath -BasePath $RootPath -TargetPath $dataFile.FullName
      $relativeSegments = $relativePath -split '[\\/]'
      $fileDirectory = Split-Path -Path $dataFile.FullName -Parent

      if ($dataFile.Name -match '^appsettings(\.[A-Za-z0-9-]+)?\.json$') {
        if (-not $projectDirectories.Contains($fileDirectory)) {
          $errors.Add("${relativePath} -> appsettings files must live next to the owning project file")
        }

        continue
      }

      $conventionDirectory = $null
      if ($relativeSegments -contains 'seed') {
        $conventionDirectory = 'seed'
      }
      elseif ($relativeSegments -contains 'fixtures') {
        $conventionDirectory = 'fixtures'
      }

      if ($null -eq $conventionDirectory) {
        $errors.Add("${relativePath} -> committed data files must live under seed/ or fixtures/ unless they are appsettings*.json")
        continue
      }

      $conventionIndex = [Array]::IndexOf($relativeSegments, $conventionDirectory)
      for ($segmentIndex = $conventionIndex + 1; $segmentIndex -lt ($relativeSegments.Length - 1); $segmentIndex++) {
        if ($relativeSegments[$segmentIndex] -notmatch '^[a-z0-9]+(-[a-z0-9]+)*$') {
          $errors.Add("${relativePath} -> nested directories under ${conventionDirectory}/ must use lowercase kebab-case")
          break
        }
      }

      if ($dataFile.BaseName -notmatch '^[a-z0-9]+(-[a-z0-9]+)*$') {
        $errors.Add("${relativePath} -> files under ${conventionDirectory}/ must use lowercase kebab-case names")
      }
    }
  }

  if ($errors.Count -gt 0) {
    throw "Sample data and fixtures validation failed:`n$($errors -join [Environment]::NewLine)"
  }
}

$requiredPaths = @(
  'README.md',
  'ROADMAP.md',
  'CONTRIBUTING.md',
  '.ai/instructions.md',
  '.ai/conventions.md',
  'docs/README.md',
  'docs/curriculum/README.md',
  'docs/process/issue-and-branch-naming.md',
  'docs/process/sample-data-and-fixtures.md',
  'docs/templates/lesson-template.md',
  'docs/templates/exercise-template.md',
  'docs/templates/review-checklist.md'
)

Push-Location $repoRoot

try {
  Write-Host "Using .NET SDK $(dotnet --version)"

  $missingPaths = @($requiredPaths | Where-Object { -not (Test-Path $_) })
  if ($missingPaths.Count -gt 0) {
    throw "Missing required scaffold files: $($missingPaths -join ', ')"
  }

  Write-Host 'Validating Markdown links'
  Test-MarkdownLinks -RootPath $repoRoot

  Write-Host 'Validating curriculum topic bundles and lesson metadata'
  Test-CurriculumTopicBundles -RootPath $repoRoot

  Write-Host 'Validating sample data and fixtures conventions'
  Test-SampleDataConventions -RootPath $repoRoot

  $solutions = Get-ChildItem -Path $repoRoot -Filter *.sln -Recurse -File
  $projects = Get-ChildItem -Path $repoRoot -Filter *.csproj -Recurse -File |
    Where-Object { $_.FullName -notmatch '[\\/](bin|obj)[\\/]' }
  $testProjects = @(
    $projects | Where-Object {
      $content = Get-Content -Path $_.FullName -Raw
      $content -match 'Microsoft\.NET\.Test\.Sdk' -or $content -match '<IsTestProject>true</IsTestProject>'
    }
  )

  if ($solutions.Count -gt 0) {
    foreach ($solution in $solutions) {
      Write-Host "Restoring solution $($solution.FullName)"
      dotnet restore $solution.FullName

      Write-Host "Building solution $($solution.FullName)"
      dotnet build $solution.FullName --configuration Release --no-restore

      if ($testProjects.Count -gt 0) {
        Write-Host "Running tests for solution $($solution.FullName)"
        dotnet test $solution.FullName --configuration Release --no-build
      }
    }
  }
  elseif ($projects.Count -gt 0) {
    foreach ($project in $projects) {
      Write-Host "Restoring project $($project.FullName)"
      dotnet restore $project.FullName

      Write-Host "Building project $($project.FullName)"
      dotnet build $project.FullName --configuration Release --no-restore
    }

    if ($testProjects.Count -gt 0) {
      foreach ($testProject in $testProjects) {
        Write-Host "Running tests for project $($testProject.FullName)"
        dotnet test $testProject.FullName --configuration Release --no-build
      }
    }
  }
  else {
    Write-Host 'No solution or project files found yet. Scaffold validation only.'
  }

  Write-Host 'Repository validation passed.'
}
finally {
  Pop-Location
}

