# Gizmox.WebGUI.Common.Design.Skins (.NET 8 Standalone Migration)

## Purpose

This project is the standalone .NET 8 migration target for the legacy `Gizmox.WebGUI.Common.Design.Skins` assembly.

It preserves a decompiled baseline from the legacy 4.5.2 binary and compiles it under .NET 8 with minimal compatibility shims for deferred Visual Studio designer services.

## Current State

- Target framework: `net8.0-windows`
- Output: class library
- Main project file: `Gizmox.WebGUI.Common.Design.Skins.csproj`
- Legacy decompiled snapshot: `legacy-decompiled/`
- Compatibility shims: `Compatibility/`
- Preserved assembly version: `4.5.25701.0`

## Compatibility Notes

- The legacy assembly depends on `EnvDTE` project services for Visual Studio-specific designer workflows.
- This migration keeps the source buildable on .NET 8 by supplying lightweight `EnvDTE` placeholder types.
- Full Visual Studio designer parity is intentionally deferred; the placeholder types are present so runtime attribute/type resolution does not fail.
- Live NetCore references to this assembly should use the simple assembly name `Gizmox.WebGUI.Common.Design.Skins` rather than the legacy strong-name identity.

## Build

Run from workspace root:

```powershell
dotnet build .\NetCore\Gizmox.WebGUI.Common.Design.Skins\Gizmox.WebGUI.Common.Design.Skins.csproj -c Debug
```