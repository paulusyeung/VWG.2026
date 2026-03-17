# Tasks

## Completed
- [x] Create new standalone project under NetCore/Gizmox.WebGUI.Common.Design.
- [x] Add migration documentation and work tracking files.
- [x] Record assembly analysis findings and scope decisions.
- [x] Decompile legacy Gizmox.WebGUI.Common.Design.dll into legacy-decompiled baseline sources.
- [x] Configure scaffold project to keep decompiled sources out of build until triaged.
- [x] Triage decompiled files into runtime-relevant and designer-only buckets.
- [x] Build an inventory of legacy design attribute type names referenced by NetCore runtime sources.
- [x] Add minimal compatibility shim types for currently referenced Common.Design type names.
- [x] Normalize live Common.Design attribute strings to simple assembly-qualified names.
- [x] Add project references so Common and Forms carry the Common.Design shim assembly at runtime.

## Next
- [ ] Categorize each remaining legacy reference as Keep, Replace, Remove, or Defer.
- [ ] Decide what to do with deferred legacy design assemblies such as `Gizmox.WebGUI.Common.Design.Skins` if those paths must work on NetCore.
- [ ] Add focused runtime tests for editor resolution and resource-handle editing paths.

## Deferred
- [ ] Full Visual Studio designer parity port.
- [ ] Full CodeDom serializer parity.
