# Tasks

## Completed

- [x] Create new standalone project under `NetCore/Gizmox.WebGUI.Forms.Professional`.
- [x] Decompile legacy `Gizmox.WebGUI.Forms.Professional.dll` into `legacy-decompiled` baseline sources.
- [x] Add .NET 8 SDK-style project file with references to migrated `Common` and `Forms`.
- [x] Preserve legacy embedded Professional image resources in the new project.
- [x] Resolve decompiler compile blockers (event registration collisions and signature artifacts).
- [x] Add Forms internal visibility bridge required by Professional extension internals.
- [x] Validate standalone project build on .NET 8.

## Next

- [ ] Triage Professional warning backlog and optionally define a NoWarn baseline for generated/decompiled patterns.
- [ ] Add targeted runtime verification scenarios for GoogleMap and ZedGraph controls.
- [ ] Decide whether to normalize legacy design/controller assembly-qualified strings for Professional design-time paths.
