# Gizmox.WebGUI.Forms.Themes (.NET 8 Standalone Migration)

## Purpose

This project is the standalone .NET 8 migration target for the legacy `Gizmox.WebGUI.Forms.Themes` assembly.

It preserves a source snapshot from the legacy 4.5.2 project and compiles it against migrated NetCore dependencies.

## Current State

- Target framework: `net8.0-windows`
- Output: class library
- Main project file: `Gizmox.WebGUI.Forms.Themes.csproj`
- Legacy source snapshot: `legacy-source/`
- Primary namespace: `Gizmox.WebGUI.Forms.Themes`
- Project references:
  - `../Gizmox.WebGUI.Common/Gizmox.WebGUI.Common.csproj`
  - `../Gizmox.WebGUI.Forms/Gizmox.WebGUI.Forms.csproj`

## Resource Compatibility

- Legacy themes are backed by `.resx` files, but runtime compatibility in .NET 8 is preserved by embedding the legacy precompiled `.resources` blobs.
- Embedded resource blobs are stored under `legacy-resourceblobs/` and sourced from legacy `obj\Debug` outputs.
- Theme `.resx` files are kept in `legacy-source/` for traceability but excluded from SDK resource generation.
- Output resource names remain legacy-compatible:
  - `Gizmox.WebGUI.Forms.Themes.<ThemeName>.resources`

## Build

Run from workspace root:

```powershell
dotnet build .\NetCore\Gizmox.WebGUI.Forms.Themes\Gizmox.WebGUI.Forms.Themes.csproj -c Debug
```
