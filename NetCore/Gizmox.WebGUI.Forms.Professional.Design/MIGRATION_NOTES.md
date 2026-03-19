# Migration Notes

Date: 2026-03-19

## Legacy Assembly Findings

- Assembly: `Gizmox.WebGUI.Forms.Professional.Design, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=fd7bc2dbb230d265`
- Legacy references:
  - `Gizmox.WebGUI.Forms.Professional`
  - `Gizmox.WebGUI.Client`
  - `Gizmox.WebGUI.Common`
  - `Gizmox.WebGUI.Common.Design`
  - `System.Design`
  - `System`
  - `mscorlib`
- Exported types: 4
  - `Gizmox.WebGUI.Forms.Google.GoogleLayerCollectionEditor`
  - `Gizmox.WebGUI.Forms.Google.GoogleLocationCollectionEditor`
  - `Gizmox.WebGUI.Forms.Google.GoogleOverlayCollectionEditor`
  - `Gizmox.WebGUI.Forms.Professional.Design.Controllers.StackPanelController`

## NetCore Migration Decisions

- Created a standalone project at `NetCore/Gizmox.WebGUI.Forms.Professional.Design`.
- Target framework set to `net8.0-windows`.
- Preserved the legacy assembly name and version.
- Referenced migrated NetCore dependencies via project references:
  - `Gizmox.WebGUI.Client`
  - `Gizmox.WebGUI.Common`
  - `Gizmox.WebGUI.Common.Design`
  - `Gizmox.WebGUI.Forms`
  - `Gizmox.WebGUI.Forms.Professional`

## Compile Compatibility Adjustments

1. Replaced the decompiled dependency on `DesignerUtils.FilterGenericTypes` with a local `GoogleDesignTypeFilter` helper because the current `Common.Design` shim does not compile the legacy `DesignerUtils` implementation.
2. Normalized the Professional runtime's design-time assembly-qualified strings to simple assembly names so the unsigned net8 `Gizmox.WebGUI.Forms.Professional.Design` output can resolve without the legacy public key token.

## Validation

- Build validation command:
  - `dotnet build NetCore/Gizmox.WebGUI.Forms.Professional.Design/Gizmox.WebGUI.Forms.Professional.Design.csproj -c Debug`
- Result: build succeeded on 2026-03-19
  - `0` errors in `Gizmox.WebGUI.Forms.Professional.Design`
  - warning volume remains inherited from upstream migrated dependencies (`Gizmox.WebGUI.Forms` / `Gizmox.WebGUI.Forms.Professional`)

## Focused Design-Time Resolution Check

- Verified direct `Type.GetType(...)` resolution from the build output for:
  - `Gizmox.WebGUI.Forms.Google.GoogleOverlayCollectionEditor, Gizmox.WebGUI.Forms.Professional.Design`
  - `Gizmox.WebGUI.Forms.Google.GoogleLayerCollectionEditor, Gizmox.WebGUI.Forms.Professional.Design`
  - `Gizmox.WebGUI.Forms.Google.GoogleLocationCollectionEditor, Gizmox.WebGUI.Forms.Professional.Design`
  - `Gizmox.WebGUI.Forms.Professional.Design.Controllers.StackPanelController, Gizmox.WebGUI.Forms.Professional.Design`
- Result (2026-03-19): all four type names resolved successfully after normalizing the Professional runtime's legacy assembly-qualified strings.

## Focused Design-Time Smoke Check

- Smoke script:
  - `NetCore/Gizmox.WebGUI.Forms.Professional.Design/SMOKE_CHECK_DESIGNTIME.ps1`
- Validation command:
  - `pwsh -File NetCore/Gizmox.WebGUI.Forms.Professional.Design/SMOKE_CHECK_DESIGNTIME.ps1`
- Result (2026-03-19): all checks passed
  - `GoogleMap.MapOverlays` editor attribute wiring and type resolution
  - `GoogleMap.MapLayers` editor attribute wiring and type resolution
  - `GoogleMapHeatMapLayer.DataPoints` editor attribute wiring and type resolution
  - `GoogleOverlayCollectionEditor.GetDisplayText` returning `GoogleMapMarkerOverlay`
  - `GoogleLayerCollectionEditor.GetDisplayText` returning `TrafficLayer`
  - `StackPanel` design-time controller attribute wiring and controller type resolution
  - `StackPanelController` constructor/base-type surface compatibility