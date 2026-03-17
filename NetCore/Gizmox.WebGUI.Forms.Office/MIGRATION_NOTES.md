# Migration Notes

Date: 2026-03-18

## Legacy Assembly Findings

- Assembly: `Gizmox.WebGUI.Forms.Office, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=d50c2c7452ba77d9`
- Legacy references:
  - `Gizmox.WebGUI.Common`
  - `Gizmox.WebGUI.Forms`
  - `System.Drawing`
  - `System`
  - `mscorlib`
- Exported types: 78
  - `Gizmox.WebGUI.Forms`: 55
  - `Gizmox.WebGUI.Forms.Skins`: 23

## NetCore Migration Decisions

- Created a standalone project at `NetCore/Gizmox.WebGUI.Forms.Office`.
- Target framework set to `net8.0-windows`.
- Preserved legacy Office image resources as embedded resources.
- Referenced migrated NetCore projects instead of legacy binaries:
  - `Gizmox.WebGUI.Common`
  - `Gizmox.WebGUI.Forms`

## Compile Blockers Resolved

1. Fixed decompiler-generated explicit interface accessor in `ScheduleBoxEventCollection` (`IList.IsReadOnly`).
2. Reworked `NavigationTab` appearance behavior to constructor-based initialization (`base.Appearance = TabAppearance.Navigation`) to avoid cross-assembly override accessibility conflict.
3. Fixed decompiler event registration/name-collision artifacts in:
   - `QuickAccessToolBar`
   - `RichTextEditor`
4. Added internal visibility bridge from Forms to Office:
   - `NetCore/Gizmox.WebGUI.Forms/Properties/InternalsVisibleTo.Office.cs`

## Validation

- `dotnet build NetCore/Gizmox.WebGUI.Forms.Office/Gizmox.WebGUI.Forms.Office.csproj -c Debug` succeeds.

## Follow-up

- Optional warning cleanup pass for nullable and decompiler-lint warnings in Office sources.
- Runtime verification for Ribbon, RichTextEditor, ScheduleBox, and QuickAccess UI flows under the NetCore host.
