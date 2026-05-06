param(
  [Parameter(Mandatory = $true)]
  [ValidatePattern('^\d{2}-[a-z0-9-]+$')]
  [string]$Stage,

  [Parameter(Mandatory = $true)]
  [string]$Topic
)

$ErrorActionPreference = 'Stop'

function ConvertTo-Slug {
  param([string]$Value)

  $slug = $Value.ToLowerInvariant() -replace '[^a-z0-9]+', '-'
  return $slug.Trim('-')
}

$repoRoot = Split-Path -Parent $PSScriptRoot
$topicSlug = ConvertTo-Slug $Topic

if ([string]::IsNullOrWhiteSpace($topicSlug)) {
  throw 'The topic name produced an empty slug. Choose a more specific topic name.'
}

$docDir = Join-Path $repoRoot "docs/curriculum/$Stage/$topicSlug"
$srcDir = Join-Path $repoRoot "src/$Stage/$topicSlug"
$exerciseDir = Join-Path $repoRoot "exercises/$Stage/$topicSlug"
$labDir = Join-Path $repoRoot "labs/$Stage/$topicSlug"

foreach ($directory in @($docDir, $srcDir, $exerciseDir, $labDir)) {
  New-Item -ItemType Directory -Path $directory -Force | Out-Null
}

$lessonTemplatePath = Join-Path $repoRoot 'docs/templates/lesson-template.md'
$exerciseTemplatePath = Join-Path $repoRoot 'docs/templates/exercise-template.md'

$topicReadmePath = Join-Path $docDir 'README.md'
$lessonPath = Join-Path $docDir 'lesson.md'
$exercisesPath = Join-Path $docDir 'exercises.md'
$checklistPath = Join-Path $docDir 'checklist.md'

if (-not (Test-Path $topicReadmePath)) {
  @(
    "# $Topic",
    '',
    '## Scope',
    '',
    '- Define the learner-facing goal for this topic.',
    '- Link the demo, exercises, and lab assets once they exist.',
    '',
    '## Status',
    '',
    '- Scaffolded'
  ) | Set-Content -Path $topicReadmePath -Encoding utf8
}

if (-not (Test-Path $lessonPath)) {
  $lessonContent = Get-Content -Path $lessonTemplatePath -Raw
  $lessonContent = $lessonContent.Replace('Lesson Title', $Topic)
  $lessonContent = $lessonContent.Replace('01-foundations', $Stage)
  $lessonContent = $lessonContent.Replace('01-topic-slug', $topicSlug)
  Set-Content -Path $lessonPath -Value $lessonContent -Encoding utf8
}

if (-not (Test-Path $exercisesPath)) {
  $exerciseContent = Get-Content -Path $exerciseTemplatePath -Raw
  $exerciseContent = $exerciseContent.Replace('Exercise Title', "$Topic Exercise")
  $exerciseContent = $exerciseContent.Replace('Lesson Title', $Topic)
  $exerciseContent = $exerciseContent.Replace('01-foundations', $Stage)
  $exerciseContent = $exerciseContent.Replace('01-topic-slug', $topicSlug)
  Set-Content -Path $exercisesPath -Value $exerciseContent -Encoding utf8
}

if (-not (Test-Path $checklistPath)) {
  @(
    '# Topic Checklist',
    '',
    '- [ ] README explains the goal of the topic.',
    '- [ ] lesson.md is complete and accurate.',
    '- [ ] exercises.md contains at least one verifiable exercise.',
    '- [ ] src/ contains a runnable demo or a placeholder note.',
    '- [ ] exercises/ contains starter assets or a placeholder note.',
    '- [ ] labs/ contains a lab plan when needed.'
  ) | Set-Content -Path $checklistPath -Encoding utf8
}

Write-Host "Scaffolded topic '$topicSlug' under stage '$Stage'."
Write-Host "Docs: $docDir"
Write-Host "Source: $srcDir"
Write-Host "Exercises: $exerciseDir"
Write-Host "Labs: $labDir"
