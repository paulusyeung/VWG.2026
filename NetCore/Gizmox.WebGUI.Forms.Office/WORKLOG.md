# Work Log

## 2026-03-18

- Created `NetCore/Gizmox.WebGUI.Forms.Office` as a standalone migration project.
- Decompiled legacy Office assembly from `Sources 4.5.2/Gizmox.WebGUI.Assemblies/bin/4.5.2/Gizmox.WebGUI.Forms.Office.dll` into `legacy-decompiled` using `ilspycmd`.
- Added new SDK-style `.NET 8` project file at `Gizmox.WebGUI.Forms.Office.csproj`.
- Wired project references to migrated `Gizmox.WebGUI.Common` and `Gizmox.WebGUI.Forms` projects.
- Preserved Office icon/image resources as embedded resources.
- Fixed initial compile blockers in decompiled sources:
  - `ScheduleBoxEventCollection` explicit interface accessor artifact.
  - `NavigationTab` cross-assembly override issue by setting base appearance in constructor.
  - `QuickAccessToolBar` and `RichTextEditor` event registration collision artifacts.
- Added `InternalsVisibleTo` bridge in `NetCore/Gizmox.WebGUI.Forms` for `Gizmox.WebGUI.Forms.Office`.
- Validated standalone Office build on .NET 8 (`dotnet build` succeeded).
- Kept this work standalone and did not modify solution files.
