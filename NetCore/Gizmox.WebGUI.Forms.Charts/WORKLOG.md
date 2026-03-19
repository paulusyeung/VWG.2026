# Work Log

## 2026-03-20

- Created `NetCore/Gizmox.WebGUI.Forms.Charts` as a standalone migration project.
- Decompiled legacy Charts assembly from `Sources 4.5.2/Gizmox.WebGUI.Assemblies/bin/4.5.2/Gizmox.WebGUI.Forms.Charts.dll` into `legacy-decompiled` using `ilspycmd`.
- Added new SDK-style .NET 8 project file at `Gizmox.WebGUI.Forms.Charts.csproj`.
- Wired project references to migrated `Gizmox.WebGUI.Common` and `Gizmox.WebGUI.Forms` projects.
- Preserved legacy embedded chart resources (`Chart_45.png` and `ChartSkin.resources`) through explicit embedded-resource configuration.
- Validated first standalone Debug build; compile succeeded without source-code blocker fixes.
- Added `GenerateResourceWarnOnBinaryFormatterUse=false` to match existing migration pattern and suppress known legacy `.resx` BinaryFormatter warnings.
- Re-validated standalone Release build on .NET 8: `0 warnings`, `0 errors`.