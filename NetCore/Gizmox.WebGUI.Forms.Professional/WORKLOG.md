# Work Log

## 2026-03-18

- Created `NetCore/Gizmox.WebGUI.Forms.Professional` as a standalone migration project.
- Decompiled legacy Professional assembly from `Sources 4.5.2/Gizmox.WebGUI.Assemblies/bin/4.5.2/Gizmox.WebGUI.Forms.Professional.dll` into `legacy-decompiled` using `ilspycmd`.
- Added new SDK-style `.NET 8` project file at `Gizmox.WebGUI.Forms.Professional.csproj`.
- Wired project references to migrated `Gizmox.WebGUI.Common` and `Gizmox.WebGUI.Forms` projects.
- Added `ZedGraph` package dependency required by Professional graph control code.
- Preserved Professional icon/image resources as embedded resources.
- Added `InternalsVisibleTo` bridge in `NetCore/Gizmox.WebGUI.Forms` for `Gizmox.WebGUI.Forms.Professional`.
- Fixed initial compile blockers in decompiled sources:
  - event/static-constructor symbol collisions in `ExpandableGroupBox`, `GoogleMap`, and `ZedGraphControl`
  - delegate/signature mismatches in `ZedGraphControl`
  - right-click overlay handler key wiring in `GoogleMap`
- Validated standalone Professional build on .NET 8 (`dotnet build` succeeded).
- Kept this work standalone and did not modify solution files.
