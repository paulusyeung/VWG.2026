# Migration Notes

Date: 2026-03-18

## Legacy Assembly Findings
- Target framework: .NET Framework 4.5.2.
- Assembly analyzed: Sources 4.5.2/Gizmox.WebGUI.Assemblies/bin/4.5.2/Gizmox.WebGUI.Common.Design.dll.
- Public exported types: 35.
- Type distribution:
  - Gizmox.WebGUI.Forms.Design: 18
  - Gizmox.WebGUI.Common.Design.Serialization: 12
  - Gizmox.WebGUI.Client.Design.Host: 4
  - Gizmox.WebGUI.Client.Design: 1
- References include legacy design-time dependencies such as System.Design, System.Drawing.Design, and System.Windows.Forms.

## Migration Constraints
- Loading all types on modern runtime raised a type-load failure related to legacy WinForms design-time contracts.
- Full design-time parity is high effort and not on the critical runtime migration path.
- In this repository, source for a dedicated Gizmox.WebGUI.Common.Design project was not found in Sources 4.5.2.
- A legacy Gizmox.WebGUI.Forms.Design project exists and references the prebuilt Common.Design binary.

## NetCore State Snapshot
- NetCore code still contains many design attributes referencing legacy assemblies by string.
- Runtime migration should prioritize keeping execution stable without requiring full legacy designer infrastructure.

## Decompilation Baseline
- Decompiler: ilspycmd 9.1.0.7988.
- Input: Sources 4.5.2/Gizmox.WebGUI.Assemblies/bin/4.5.2/Gizmox.WebGUI.Common.Design.dll.
- Output: NetCore/Gizmox.WebGUI.Common.Design/legacy-decompiled.
- Generated artifacts include:
  - Decompilation project file: legacy-decompiled/Gizmox.WebGUI.Common.Design.csproj
  - C# source files: 34
  - Obfuscated helper files in namespace A: 9
- Note: Decompiled files are intentionally excluded from compilation in the net8 scaffold project. They are a migration source baseline.

## Runtime Triage and Shim
- Built a concrete inventory of 15 type names referenced from NetCore generated attributes.
- Added minimal compatibility placeholders for those referenced names under `Compatibility/`.
- Serializer placeholders are pass-through implementations that delegate to base component serializer when available.
- Designer placeholders provide type presence only (full Visual Studio design host behavior remains deferred).

## Strong-Name Caveat
- Legacy attribute strings originally referenced `Gizmox.WebGUI.Common.Design` with legacy version and public key token.
- Live NetCore generated sources now normalize those `Gizmox.WebGUI.Common.Design` references to simple assembly-qualified names, and consuming NetCore projects reference the shim so the assembly is available at runtime.
- Exact legacy assembly-qualified strings still fail against the new shim assembly due identity mismatch if encountered elsewhere.
- Current validation leaves the legacy token only in backup-only content (`Gizmox.WebGUI.Common.decompiled.cs.bak`) and both `Gizmox.WebGUI.Common` and `Gizmox.WebGUI.Forms` build successfully after the normalization change.

## Decision
- Keep this project as a migration anchor and documentation home.
- Defer full design-support port.
- Implement minimal runtime-safe replacements for currently referenced names while keeping legacy behavior deferred.
