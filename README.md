# Gizmox.WebGUI .NET 8 Migration

## Quick start

1. Install .NET 8 SDK
2. `cd c:\Projects\VWG`
3. `dotnet test "NetCore\Gizmox.WebGUI.BlazorPilot\Gizmox.WebGUI.BlazorPilot.sln" --logger "console;verbosity=minimal"`

## Playwright

- Run once:
  - `pwsh NetCore\Gizmox.WebGUI.BlazorPilot.Tests\bin\Debug\net9.0\playwright.ps1 install`
- Skip e2e in CI/local with:
  - `setx PLAYWRIGHT_SKIP true` (Windows)
  - `$env:PLAYWRIGHT_SKIP = "true"` (PowerShell)

## Docker

- `cd NetCore/Gizmox.WebGUI.BlazorPilot`
- `docker build -t gizmox/webgui-blazorpilot:dev .`
- `docker run -d -p 5050:80 --name vwg-blazorpilot gizmox/webgui-blazorpilot:dev`

## CI

- GitHub Actions pipelines:
  - `.github/workflows/dotnet-test.yml` (build, tests, coverage, format, vuln scan)
  - `.github/workflows/publish-container.yml` (Docker build & ghcr push)

## Phase 4 status

- Testing: green
- Cycle gating: formatting and coverage thresholds active
- Release: Docker image pipeline configured
- Dependency automation: `.github/dependabot.yml` set weekly updates
