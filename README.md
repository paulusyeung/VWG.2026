# Gizmox.WebGUI .NET 8 Migration

## Quick start

1. Install .NET 8 SDK
2. `cd c:\Projects\VWG`
3. `dotnet test "NetCore\Gizmox.WebGUI.BlazorPilot\Gizmox.WebGUI.BlazorPilot.sln" --logger "console;verbosity=minimal"`
4. `dotnet build "NetCore\Gizmox.WebGUI.Server\Gizmox.WebGUI.Server.csproj" -v minimal`

## Playwright

- Run once:
  - `pwsh NetCore\Gizmox.WebGUI.BlazorPilot.Tests\bin\Debug\net8.0\playwright.ps1 install`
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

- Core compile status: 5/5 libraries building (Common, Forms, Converters, Client, Server)
- Warning reduction: iterative passes reduced Server warnings from 670 to 0 on clean `Gizmox.WebGUI.Server.csproj` rebuilds (`670 -> 218 -> 191 -> 161 -> 140 -> 126 -> 110 -> 98 -> 84 -> 73 -> 48 -> 31 -> 0`; incremental up-to-date direct builds can show 0)
- Testing: green for Common.Tests and BlazorPilot.Tests
- Cycle gating: formatting and coverage thresholds active
- Release: Docker image pipeline configured
- Dependency automation: `.github/dependabot.yml` set weekly updates
