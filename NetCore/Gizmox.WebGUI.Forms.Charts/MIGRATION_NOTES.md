# Migration Notes

Date: 2026-03-20

## Legacy Assembly Findings

- Assembly: `Gizmox.WebGUI.Forms.Charts, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=f1bb83df6a8597fb`
- Legacy references:
  - `Gizmox.WebGUI.Common`
  - `Gizmox.WebGUI.Forms`
  - `System.Xml`
  - `System`
  - `System.Drawing`
  - `mscorlib`
- Exported types: 16
  - `Gizmox.WebGUI.Forms.Charts`
  - `Gizmox.WebGUI.Forms.Charts.Skins`
- Embedded resources:
  - `Gizmox.WebGUI.Forms.Charts.Chart_45.png`
  - `Gizmox.WebGUI.Forms.Charts.Skins.ChartSkin.resources`

## NetCore Migration Decisions

- Created a standalone project at `NetCore/Gizmox.WebGUI.Forms.Charts`.
- Target framework set to `net8.0-windows`.
- Preserved legacy embedded resources with explicit logical names.
- Referenced migrated NetCore projects instead of legacy binaries:
  - `Gizmox.WebGUI.Common`
  - `Gizmox.WebGUI.Forms`
- Set `GenerateResourceWarnOnBinaryFormatterUse=false` to suppress known MSB3825 warnings from legacy `.resx` skin payloads.

## Compile Blockers Resolved

- No decompiler source compile blockers were encountered in this assembly on first build.

## Validation

- `dotnet build NetCore/Gizmox.WebGUI.Forms.Charts/Gizmox.WebGUI.Forms.Charts.csproj -c Debug` succeeds.
- `dotnet build NetCore/Gizmox.WebGUI.Forms.Charts/Gizmox.WebGUI.Forms.Charts.csproj -c Release` succeeds.
- Current warning baseline after project-level warning hardening: `0 warnings`, `0 errors` (Release build).

## Follow-up

- Optional runtime verification for chart rendering themes/series behaviors in host applications.