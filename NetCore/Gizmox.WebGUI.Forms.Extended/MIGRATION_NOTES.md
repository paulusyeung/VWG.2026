# Migration Notes

Date: 2026-03-18

## Legacy Assembly Findings

- Assembly: `Gizmox.WebGUI.Forms.Extended, Version=4.5.25701.0, Culture=neutral, PublicKeyToken=85eae29607c9f5f3`
- Legacy references:
  - `mscorlib`
  - `Gizmox.WebGUI.Common`
  - `System`
  - `System.Drawing`
  - `Gizmox.WebGUI.Forms`
  - `System.Web.Extensions`
  - `System.Web`
  - `System.Configuration`
- Exported types: 31
  - `Gizmox.WebGUI.Common.Resources`: 2
  - `Gizmox.WebGUI.Forms`: 19
  - `Gizmox.WebGUI.Forms.Editors`: 2
  - `Gizmox.WebGUI.Forms.Editors.Skins`: 1
  - `Gizmox.WebGUI.Forms.Extended`: 2
  - `Gizmox.WebGUI.Forms.Skins`: 5

## NetCore Migration Decisions

- Created a standalone project at `NetCore/Gizmox.WebGUI.Forms.Extended`.
- Target framework set to `net8.0-windows`.
- Preserved legacy embedded image resources with explicit logical names.
- Referenced migrated NetCore projects instead of legacy binaries:
  - `Gizmox.WebGUI.Common`
  - `Gizmox.WebGUI.Forms`

## Compile Blockers Resolved

1. Replaced legacy `System.Web.Script.Serialization.JavaScriptSerializer` usage in `UploadControl` with `System.Text.Json.JsonSerializer`.
2. Fixed decompiler-generated event registration/handler artifacts by wiring `SerializableEvent` backing fields in:
   - `UploadControl`
   - `FCKEditor`
3. Added `ApplicationPath` to the NetCore `System.Web` shim `HttpRequest` to match legacy API usage in `FCKEditor`.

## Validation

- `dotnet build NetCore/Gizmox.WebGUI.Forms.Extended/Gizmox.WebGUI.Forms.Extended.csproj -c Debug` succeeds.
- Current warning baseline: 5749 warnings, 0 errors.

## Follow-up

- Optional warning cleanup pass for nullable and decompiler-lint warnings in Extended sources.
- Runtime verification for upload flows, workspace tabs rendering, and FCKEditor integration paths.
