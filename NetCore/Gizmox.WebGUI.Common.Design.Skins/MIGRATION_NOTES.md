# Migration Notes

Date: 2026-03-19

## Legacy Assembly Findings
- Source project was not present in `Sources 4.5.2`; migration started from the shipped `Gizmox.WebGUI.Common.Design.Skins.dll` binary.
- Assembly identity: `Gizmox.WebGUI.Common.Design.Skins`, version `4.5.25701.0`, public key token `82814e180535b402`.
- The DLL contains real code plus embedded WinForms resources; it is not a resource-only wrapper.
- Key exported areas include document designers, CodeDom serializers, editors, and WinForms dialogs.

## Decompilation Baseline
- Decompiler: `ilspycmd.exe`
- Input: `Sources 4.5.2/Gizmox.WebGUI.Assemblies/bin/4.5.2/Gizmox.WebGUI.Common.Design.Skins.dll`
- Output: `NetCore/Gizmox.WebGUI.Common.Design.Skins/legacy-decompiled/`

## Migration Constraints
- The decompiled source depends on `EnvDTE` services such as `ProjectItem`, `CodeElement`, and `Window`.
- Those types are only used through service lookups for Visual Studio designer workflows.
- Full VS designer integration is not required for runtime migration and is deferred.

## NetCore Strategy
- Build the decompiled source in a standalone `net8.0-windows` project.
- Preserve the legacy assembly simple name and version, but do not depend on the legacy strong-name token.
- Supply lightweight `EnvDTE` placeholders in `Compatibility/EnvDTEStubs.cs` so the assembly compiles on .NET 8.
- Normalize live NetCore attribute strings to reference `Gizmox.WebGUI.Common.Design.Skins` by simple assembly name.

## Resource Handling
- Keep the decompiled `.resx` files in place and build them with `GenerateResourceUsePreserializedResources=true`.
- Reference `System.Resources.Extensions` so non-string designer resources remain loadable at runtime.