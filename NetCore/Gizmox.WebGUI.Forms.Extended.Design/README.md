# Gizmox.WebGUI.Forms.Extended.Design (.NET 8 Standalone Migration)

## Purpose

This project is the standalone .NET 8 migration target for the legacy `Gizmox.WebGUI.Forms.Extended.Design` assembly.

It preserves a decompiled baseline from the legacy 4.5.2 binary and compiles it under .NET 8 against migrated NetCore dependencies.

## Current State

- Target framework: `net8.0-windows`
- Output: class library
- Main project file: `Gizmox.WebGUI.Forms.Extended.Design.csproj`
- Legacy decompiled snapshot: `legacy-decompiled/`
- Preserved assembly version: `4.5.25701.0`

## Build

Run from workspace root:

```powershell
dotnet build .\NetCore\Gizmox.WebGUI.Forms.Extended.Design\Gizmox.WebGUI.Forms.Extended.Design.csproj -c Debug
```