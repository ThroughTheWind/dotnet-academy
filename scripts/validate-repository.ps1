$ErrorActionPreference = 'Stop'

$repoRoot = Split-Path -Parent $PSScriptRoot
$requiredPaths = @(
  'README.md',
  'ROADMAP.md',
  'CONTRIBUTING.md',
  '.ai/instructions.md',
  '.ai/conventions.md',
  'docs/curriculum/README.md',
  'docs/templates/lesson-template.md',
  'docs/templates/exercise-template.md'
)

Push-Location $repoRoot

try {
  Write-Host "Using .NET SDK $(dotnet --version)"

  $missingPaths = @($requiredPaths | Where-Object { -not (Test-Path $_) })
  if ($missingPaths.Count -gt 0) {
    throw "Missing required scaffold files: $($missingPaths -join ', ')"
  }

  $solutions = Get-ChildItem -Path $repoRoot -Filter *.sln -Recurse -File
  $projects = Get-ChildItem -Path $repoRoot -Filter *.csproj -Recurse -File |
    Where-Object { $_.FullName -notmatch '[\\/](bin|obj)[\\/]' }

  if ($solutions.Count -gt 0) {
    foreach ($solution in $solutions) {
      Write-Host "Restoring solution $($solution.FullName)"
      dotnet restore $solution.FullName

      Write-Host "Building solution $($solution.FullName)"
      dotnet build $solution.FullName --configuration Release --no-restore
    }
  }
  elseif ($projects.Count -gt 0) {
    foreach ($project in $projects) {
      Write-Host "Restoring project $($project.FullName)"
      dotnet restore $project.FullName

      Write-Host "Building project $($project.FullName)"
      dotnet build $project.FullName --configuration Release --no-restore
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
