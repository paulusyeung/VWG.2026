# Migration Notes

Date: 2026-03-19

## Legacy Assembly Findings

- Assembly: `Gizmox.WebGUI.Forms.Office.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=e838c68aaf727726`
- Legacy references:
  - `Gizmox.WebGUI.Client`
  - `Gizmox.WebGUI.Common`
  - `Gizmox.WebGUI.Forms`
  - `Gizmox.WebGUI.Forms.Design`
  - `Gizmox.WebGUI.Forms.Office`
  - `System.Design`
  - `System.Drawing`
  - `System.Windows.Forms`
  - `System`
  - `mscorlib`
- Exported types: 24
  - `Gizmox.WebGUI.Forms.Office.Design`
  - `Gizmox.WebGUI.Forms.Office.Design.Controllers`
  - `Gizmox.WebGUI.Forms.Office.Design.Editors`

## NetCore Migration Decisions

- Created a standalone project at `NetCore/Gizmox.WebGUI.Forms.Office.Design`.
- Target framework set to `net8.0-windows`.
- Preserved legacy assembly name and version.
- Referenced migrated NetCore projects instead of legacy binaries:
  - `Gizmox.WebGUI.Client`
  - `Gizmox.WebGUI.Common`
  - `Gizmox.WebGUI.Forms`
  - `Gizmox.WebGUI.Forms.Office`

## Compile Blockers Resolved

1. Restored missing `ContextualTabGroupEditor` base class (expected by decompiled `RibbonBarPageContextualTabGroupEditor`) by adding a compatibility implementation under:
  - `legacy-decompiled/Gizmox/WebGUI/Forms/Design/ContextualTabGroupEditor.cs`
2. Added internal visibility bridge from Office to Office.Design so the editor can access `RibbonBarPage.TabPage`:
  - `NetCore/Gizmox.WebGUI.Forms.Office/Properties/InternalsVisibleTo.Office.Design.cs`

## Validation

- Build validation command:
  - `dotnet build NetCore/Gizmox.WebGUI.Forms.Office.Design/Gizmox.WebGUI.Forms.Office.Design.csproj -c Debug`
- Result: build succeeded (warnings remain in migrated dependencies, no Office.Design compile errors).

## Focused Design-Time Smoke Check

- Smoke script:
  - `NetCore/Gizmox.WebGUI.Forms.Office.Design/SMOKE_CHECK_DESIGNTIME.ps1`
- Validation command:
  - `pwsh -File NetCore/Gizmox.WebGUI.Forms.Office.Design/SMOKE_CHECK_DESIGNTIME.ps1`
- Result (2026-03-19): all checks passed
  - Editor type load (`RibbonBarPageContextualTabGroupEditor`)
  - `RibbonBarPage.ContextualTabGroup` editor attribute wiring
  - `RibbonBarPageContextualTabGroupEditor.EditValue` flow with a fake design-time editor service returning a contextual group selection
