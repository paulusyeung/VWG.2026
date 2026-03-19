# Gizmox.WebGUI.Forms.Charts (.NET 8 Standalone Migration)

## Purpose

This project is the standalone .NET 8 migration target for the legacy `Gizmox.WebGUI.Forms.Charts` assembly.

It preserves a decompiled baseline from the legacy 4.5.2 binary and compiles it against migrated NetCore dependencies.

## Current State

- Target framework: `net8.0-windows`
- Output: class library
- Main project file: `Gizmox.WebGUI.Forms.Charts.csproj`
- Decompiled baseline: `legacy-decompiled/`
- Primary namespaces:
  - `Gizmox.WebGUI.Forms.Charts`
  - `Gizmox.WebGUI.Forms.Charts.Skins`
- Project references:
  - `../Gizmox.WebGUI.Common/Gizmox.WebGUI.Common.csproj`
  - `../Gizmox.WebGUI.Forms/Gizmox.WebGUI.Forms.csproj`

## Notes

- The legacy assembly was decompiled using `ilspycmd` into one-file-per-type source layout under `legacy-decompiled`.
- Legacy assembly metadata:
  - `Gizmox.WebGUI.Forms.Charts, Version=4.5.25701.0`
  - Public key token: `f1bb83df6a8597fb`

## Build

Run from workspace root:

```powershell
dotnet build .\NetCore\Gizmox.WebGUI.Forms.Charts\Gizmox.WebGUI.Forms.Charts.csproj -c Debug
```

## Migration Scope

This milestone establishes compile parity on .NET 8 for the Charts extension assembly in a standalone project.

Behavioral and runtime parity validation remain follow-up tasks.