# Migration Notes

Date: 2026-03-19

## Legacy Assembly Findings

- Legacy source project exists at `Sources 4.5.2/Gizmox.WebGUI.Forms.Extended.Design`.
- Assembly identity: `Gizmox.WebGUI.Forms.Extended.Design`, version `4.5.25701.0`.
- Source surface is small and controller-focused (MaskedComboBox, DataGridView masked column, WorkspaceTabs).
- The provided `obj/Release` folder contains build caches only; the loadable assembly was taken from `bin/Gizmox.WebGUI.Forms.Extended.Design.dll`.

## Decompilation Baseline

- Decompiler: `ilspycmd.exe`
- Input: `Sources 4.5.2/Gizmox.WebGUI.Forms.Extended.Design/bin/Gizmox.WebGUI.Forms.Extended.Design.dll`
- Output: `NetCore/Gizmox.WebGUI.Forms.Extended.Design/legacy-decompiled/`

## NetCore Strategy

- Build decompiled source in a standalone `net8.0-windows` project.
- Preserve legacy assembly name and version.
- Reference migrated NetCore dependencies via project references:
  - `Gizmox.WebGUI.Client`
  - `Gizmox.WebGUI.Common`
  - `Gizmox.WebGUI.Forms`
  - `Gizmox.WebGUI.Forms.Extended`

## Validation

- Build validation is performed with:
  - `dotnet build NetCore/Gizmox.WebGUI.Forms.Extended.Design/Gizmox.WebGUI.Forms.Extended.Design.csproj -c Debug`