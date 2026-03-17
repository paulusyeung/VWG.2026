# Tasks

## Completed

- [x] Create new standalone project under `NetCore/Gizmox.WebGUI.Forms.Office`.
- [x] Decompile legacy `Gizmox.WebGUI.Forms.Office.dll` into `legacy-decompiled` baseline sources.
- [x] Add .NET 8 SDK-style project file with references to migrated `Common` and `Forms`.
- [x] Preserve legacy embedded Office image resources in the new project.
- [x] Resolve decompiler compile blockers (event registration collisions and interface accessor artifact).
- [x] Add Forms internal visibility bridge required by Office extension internals.
- [x] Validate standalone project build on .NET 8.

## Next

- [ ] Triage Office warning backlog and optionally define a NoWarn baseline for generated/decompiled patterns.
- [ ] Add targeted runtime verification scenarios for key Office controls.
- [ ] Decide whether to normalize legacy design/controller assembly-qualified strings for Office design-time paths.
