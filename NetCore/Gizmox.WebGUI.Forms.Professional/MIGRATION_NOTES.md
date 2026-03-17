# Migration Notes

Date: 2026-03-18

## Legacy Assembly Findings

- Assembly: `Gizmox.WebGUI.Forms.Professional, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=6b5c571512bede7c`
- Legacy references:
  - `Gizmox.WebGUI.Common`
  - `Gizmox.WebGUI.Forms`
  - `ZedGraph`
  - `System.Drawing`
  - `System`
  - `mscorlib`
- Exported types: 83
  - `Gizmox.WebGUI.Forms`: 5
  - `Gizmox.WebGUI.Forms.Google`: 61
  - `Gizmox.WebGUI.Forms.Google.Design.Editors`: 2
  - `Gizmox.WebGUI.Forms.Google.Skins`: 1
  - `Gizmox.WebGUI.Forms.Professional`: 12
  - `Gizmox.WebGUI.Forms.ZedGraph`: 2

## NetCore Migration Decisions

- Created a standalone project at `NetCore/Gizmox.WebGUI.Forms.Professional`.
- Target framework set to `net8.0-windows`.
- Preserved legacy embedded image resources with explicit logical names.
- Referenced migrated NetCore projects instead of legacy binaries:
  - `Gizmox.WebGUI.Common`
  - `Gizmox.WebGUI.Forms`
- Added `ZedGraph` package reference for graph runtime types.

## Compile Blockers Resolved

1. Added Forms internal visibility bridge required by Professional extension internals:
   - `NetCore/Gizmox.WebGUI.Forms/Properties/InternalsVisibleTo.Professional.cs`
2. Fixed decompiler-generated event registration/handler artifacts in:
   - `ExpandableGroupBox`
   - `GoogleMap`
   - `ZedGraphControl`
3. Corrected `GoogleMap` overlay right-click handler wiring to right-click event keys.
4. Updated `ZedGraphControl` API usages for current ZedGraph signatures:
   - `FindNearestPaneObject(..., out ..., out ..., out ...)`
   - `ReverseTransform(..., out ..., out ..., out ..., out ...)`
   - `ZoomState.StateType` enum qualification
5. Stabilized obsolete zed mouse compatibility events to use dedicated backing delegates.

## Validation

- `dotnet build NetCore/Gizmox.WebGUI.Forms.Professional/Gizmox.WebGUI.Forms.Professional.csproj -c Debug` succeeds.
- Current warning baseline: 199 warnings, 0 errors.

## Follow-up

- Optional warning cleanup pass for nullable and decompiler-lint warnings in Professional sources.
- Runtime verification for GoogleMap overlays/layers and ZedGraph control interaction flows.
