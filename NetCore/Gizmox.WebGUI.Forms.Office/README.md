# Gizmox.WebGUI.Forms.Office (.NET 8 Standalone Migration)

## Purpose

This project is the standalone .NET 8 migration target for the legacy `Gizmox.WebGUI.Forms.Office` assembly.

It preserves a decompiled baseline from the legacy 4.5.2 binary and compiles it against the migrated NetCore `Common` and `Forms` projects.

## Current State

- Target framework: `net8.0-windows`
- Output: class library
- Main project file: `Gizmox.WebGUI.Forms.Office.csproj`
- Decompiled baseline: `legacy-decompiled/`
- Primary namespaces:
  - `Gizmox.WebGUI.Forms`
  - `Gizmox.WebGUI.Forms.Skins`
- Project references:
  - `../Gizmox.WebGUI.Common/Gizmox.WebGUI.Common.csproj`
  - `../Gizmox.WebGUI.Forms/Gizmox.WebGUI.Forms.csproj`

## Notes

- The legacy assembly was decompiled using `ilspycmd` into one-file-per-type source layout under `legacy-decompiled`.
- Legacy assembly metadata:
  - `Gizmox.WebGUI.Forms.Office, Version=4.5.25701.0`
  - Public key token: `d50c2c7452ba77d9`
- NetCore `Forms` now exposes internals to this assembly via:
  - `../Gizmox.WebGUI.Forms/Properties/InternalsVisibleTo.Office.cs`

## Build

Run from workspace root:

```powershell
dotnet build .\NetCore\Gizmox.WebGUI.Forms.Office\Gizmox.WebGUI.Forms.Office.csproj -c Debug
```

## Migration Scope

This milestone establishes compile parity on .NET 8 for the Office extension assembly in a standalone project.

Behavioral/runtime parity and warning cleanup remain follow-up tasks.
