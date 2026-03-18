# Migration Notes

Date: 2026-03-19

## Legacy Assembly Findings

- Assembly: `Gizmox.WebGUI.Forms.Help, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=null`
- Legacy references:
  - `mscorlib`
  - `Gizmox.WebGUI.Common`
  - `System`
  - `System.Data`
  - `ICSharpCode.SharpZipLib`
  - `Gizmox.WebGUI.Forms`
  - `System.Web`
  - `System.Drawing`
- Exported types: 39
  - `Gizmox.WebGUI.Forms`: 4
  - `Gizmox.WebGUI.Forms.Skins`: 1
  - `HtmlHelp`: 22
  - `HtmlHelp.ChmDecoding`: 7
  - `HtmlHelp.Storage`: 5

## NetCore Migration Decisions

- Created a standalone project at `NetCore/Gizmox.WebGUI.Forms.Help`.
- Target framework set to `net8.0-windows`.
- Referenced migrated NetCore projects instead of legacy binaries:
  - `Gizmox.WebGUI.Common`
  - `Gizmox.WebGUI.Forms`
- Added NuGet package dependency for CHM/zip support:
  - `SharpZipLib` (1.4.2)
- Preserved legacy content deployment behavior for:
  - `legacy-decompiled/HtmlHelp/HtmlHelp.txt`

## Compile Blockers Resolved

1. Replaced legacy .NET Framework COM interop type dependencies removed in modern .NET:
   - `UCOMIStream` -> `System.Runtime.InteropServices.ComTypes.IStream`
   - `STATSTG` -> `System.Runtime.InteropServices.ComTypes.STATSTG`
   - `FILETIME` -> `System.Runtime.InteropServices.ComTypes.FILETIME`
2. Applied compatibility aliases in `GlobalComAliases.cs` to avoid broad code churn in decompiled sources.

## Solution Integration

- Added project to `Sources 2026/VWG2026.sln`.

## Validation

- `dotnet build NetCore/Gizmox.WebGUI.Forms.Help/Gizmox.WebGUI.Forms.Help.csproj -c Debug -t:Rebuild` succeeds.
- Current warning baseline (full dependency rebuild): 6197 warnings, 0 errors.

## Follow-up

- Optional warning cleanup pass (nullable and legacy/decompiler warnings) in Help sources.
- Runtime verification for CHM navigation, topic index/search, and static gateway resource delivery.