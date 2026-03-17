# Gizmox.WebGUI.Forms.Professional (.NET 8 Standalone Migration)

## Purpose

This project is the standalone .NET 8 migration target for the legacy `Gizmox.WebGUI.Forms.Professional` assembly.

It preserves a decompiled baseline from the legacy 4.5.2 binary and compiles it against migrated NetCore dependencies.

## Current State

- Target framework: `net8.0-windows`
- Output: class library
- Main project file: `Gizmox.WebGUI.Forms.Professional.csproj`
- Decompiled baseline: `legacy-decompiled/`
- Primary namespaces:
  - `Gizmox.WebGUI.Forms`
  - `Gizmox.WebGUI.Forms.Google`
  - `Gizmox.WebGUI.Forms.Professional`
  - `Gizmox.WebGUI.Forms.ZedGraph`
- Project references:
  - `../Gizmox.WebGUI.Common/Gizmox.WebGUI.Common.csproj`
  - `../Gizmox.WebGUI.Forms/Gizmox.WebGUI.Forms.csproj`
- Package references:
  - `ZedGraph` (`5.1.7`)

## Notes

- The legacy assembly was decompiled using `ilspycmd` into one-file-per-type source layout under `legacy-decompiled`.
- Legacy assembly metadata:
  - `Gizmox.WebGUI.Forms.Professional, Version=4.5.25701.0`
  - Public key token: `6b5c571512bede7c`
- NetCore `Forms` now exposes internals to this assembly via:
  - `../Gizmox.WebGUI.Forms/Properties/InternalsVisibleTo.Professional.cs`

## Build

Run from workspace root:

```powershell
dotnet build .\NetCore\Gizmox.WebGUI.Forms.Professional\Gizmox.WebGUI.Forms.Professional.csproj -c Debug
```

## Migration Scope

This milestone establishes compile parity on .NET 8 for the Professional extension assembly in a standalone project.

Behavioral/runtime parity and warning cleanup remain follow-up tasks.
