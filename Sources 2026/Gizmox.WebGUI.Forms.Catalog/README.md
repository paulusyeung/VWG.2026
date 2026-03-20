# Gizmox.WebGUI.Forms.Catalog (.NET 8 Migration Notes)

## Overview

This project is the migrated .NET 8 version of the legacy Catalog sample from:

- Source legacy project: `../Sources 4.5.2/Gizmox.WebGUI.Forms.Catalog`
- Migrated project: `./Sources 2026/Gizmox.WebGUI.Forms.Catalog`

The current migration target is a stable build with non-migrated legacy features excluded.

## Current Status

- Build status: **Succeeded**
- Latest verification: **0 errors / 0 warnings**
- Target framework: `net8.0-windows`

## Work Completed (This Migration/Debug Session)

### 1) Fixed hard build blockers

- Added package references required by migrated legacy sources:
  - `System.Resources.Extensions`
  - `System.Configuration.ConfigurationManager`
  - `System.Data.OleDb`
  - `System.Drawing.Common`
- Resolved `ConfigurationManager` ambiguity by fully qualifying calls with `System.Configuration.ConfigurationManager`.
- Replaced unsupported legacy CAS/OleDb permission check path with exception-safe fallback logic in `DatabaseData`.
- Updated startup redirect logic in `Default.aspx.cs` to use a direct redirect path that works in the migrated context.
- Removed obsolete/useless legacy `System.Web.*` using directives where they caused compile issues.

### 2) Excluded non-migrated Reporting and ASPX-hosted sample pages

Per migration scope, Reporting support is intentionally excluded (no migrated `Gizmox.WebGUI.Reporting.dll`).

Excluded from compile:

- `Categories/DataControls/ReportViewerControl.cs`
- `Categories/Gateways/ASPX/AspPageControl.cs`
- `Categories/Gateways/ASPX/AspPageForm.aspx.cs`

Catalog/runtime config cleanup (`Web.config`):

- Removed `ReportViewerControl` catalog module/node
- Removed `AspPageBox` catalog module/node
- Removed `Reserved.ReportViewerWebControl.axd` handler

### 3) Reduced warning baseline to zero

Warning reduction approach:

- Switched project TFM to `net8.0-windows` for Windows-only UI surface compatibility.
- Set `Nullable` to `disable` for legacy/decompiled code style alignment.
- Added a focused `NoWarn` set for low-signal legacy warnings:
  - `CS0067`, `CS0252`, `CS0414`, `CS0618`, `CS8767`, `CS8769`
- Fixed remaining warning sites directly in source:
  - Removed unused local in `ToolBarControl`
  - Initialized designer `components` field in `ResultsUsage`
  - Marked legacy serialization constructor in `DatabaseData` as obsolete

Observed progression:

- Early post-fix baseline: ~`9453` warnings, `0` errors
- After warning pass: `0` warnings, `0` errors

## Build Instructions

From repository root:

```powershell
dotnet build "Sources 2026/Gizmox.WebGUI.Forms.Catalog/Gizmox.WebGUI.Forms.Catalog.csproj" -v minimal
```

## Notes for Future Migration Work

If Reporting is migrated later:

1. Restore reporting assembly/package references.
2. Re-include `ReportViewerControl.cs` in project compile items.
3. Restore report-related module/node/handler entries in `Web.config`.

If ASPX hosted gateway sample support is restored later:

1. Ensure `AspPageBox` and `AspPageBase` are available in migrated assemblies.
2. Re-include ASPX sample code-behind files.
3. Restore `AspPageBox` module/node entries in `Web.config`.

## Files Updated During This Work

- `Gizmox.WebGUI.Forms.Catalog.csproj`
- `Web.config`
- `Default.aspx.cs`
- `DatabaseData.cs`
- `CatalogSettings.cs`
- `Applications/ClassBrowser/Library/ConsoleInfo.cs`
- `Categories/Behaviors/DragAndDropBehavior.cs`
- `Extensions/Office/RichTextEditorSample.cs`
- `RandomData.cs`
- `Categories/ActionControls/ToolBarControl.cs`
- `Categories/Behaviors/ResultsUsage.cs`

---

Document updated: 2026-03-21
