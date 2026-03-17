# Decompiled Source Triage

Date: 2026-03-18

## Scope
- Input baseline: `legacy-decompiled/` (34 C# files from legacy DLL).
- NetCore reference scan: attribute-driven references to 15 type names in `Gizmox.WebGUI.Common.Design`.

## Bucket A: Referenced Type Names (Shimmed)
These names appear in current NetCore source and can be requested through attribute resolution.

- `Gizmox.WebGUI.Common.Design.ResourceFileEditor`
- `Gizmox.WebGUI.Common.Design.Serialization.AspControlBoxCodeDomSerializer`
- `Gizmox.WebGUI.Common.Design.Serialization.BindingNavigatorCodeDomSerializer`
- `Gizmox.WebGUI.Common.Design.Serialization.ControlCodeDomSerializer`
- `Gizmox.WebGUI.Common.Design.Serialization.ControlCollectionCodeDomSerializer`
- `Gizmox.WebGUI.Common.Design.Serialization.ImageListCodeDomSerializer`
- `Gizmox.WebGUI.Common.Design.Serialization.ObjectBoxParameterCollectionSelrializer`
- `Gizmox.WebGUI.Common.Design.Serialization.ResourceHandleSerializer`
- `Gizmox.WebGUI.Common.Design.Serialization.TableLayoutControlCollectionCodeDomSerializer`
- `Gizmox.WebGUI.Common.Design.Serialization.TableLayoutPanelCodeDomSerializer`
- `Gizmox.WebGUI.Common.Design.Serialization.TypeResourceHandleSerializer`
- `Gizmox.WebGUI.Forms.Design.ControlDesigner`
- `Gizmox.WebGUI.Forms.Design.FormDocumentDesigner`
- `Gizmox.WebGUI.Forms.Design.MappedComponentDesigner`
- `Gizmox.WebGUI.Forms.Design.UserControlDocumentDesigner`

## Bucket B: Legacy Designer Host Stack (Deferred)
These are substantial design-time infrastructure types from decompiled output and are intentionally deferred.

- `Gizmox.WebGUI.Forms.Design.DocumentDesigner`
- `Gizmox.WebGUI.Forms.Design.SurfaceExtender`
- `Gizmox.WebGUI.Client.Design.Host.ClientSite`
- `Gizmox.WebGUI.Client.Design.Host.ClientDesignerExtenders`
- Obfuscated host and transaction internals under `legacy-decompiled/A/*`

## Bucket C: Obfuscated/Legacy Helper Types (Deferred)
- Namespace `A` files include obfuscated runtime/design helpers and resource loader code.
- These are kept for archaeology only and are not compile candidates.

## Compatibility Shim Strategy
- Added minimal no-op compatibility types under `Compatibility/`.
- Serializer placeholders use pass-through behavior to base component serializer when available.
- Designer placeholders provide lightweight type presence only (no full VS designer implementation).

## Important Caveat: Strong-Name Identity
- Legacy attribute strings originally included full assembly identity with version and public key token.
- Live NetCore generated sources now use non-versioned `Gizmox.WebGUI.Common.Design` assembly-qualified names and consuming projects reference the shim assembly.
- Exact legacy strings still fail to resolve against the new shim assembly if encountered elsewhere because identity does not match the legacy token.

## Follow-Up Options
1. Completed for live Common.Design references: normalize generated code to a non-versioned assembly name.
2. Locate the original signing key for `Gizmox.WebGUI.Common.Design` and sign the shim with matching identity if exact legacy identity becomes necessary.
3. Apply the same normalization or porting strategy to other deferred design assemblies if those paths become active.
