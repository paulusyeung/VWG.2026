# Decompilation Workflow

Date: 2026-03-19

## Goal

Create a reproducible source baseline from the legacy Professional.Design assembly for staged migration to .NET 8.

## Source Assembly

- `C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.Professional.Design.dll`

## Tooling

- `ilspycmd` 9.1.0.7988

## Command

```powershell
ilspycmd --nested-directories -p -o .\NetCore\Gizmox.WebGUI.Forms.Professional.Design\legacy-decompiled `
  "C:\Program Files (x86)\Gizmox\Visual WebGUI\SDK 4.5.2\Assemblies\Gizmox.WebGUI.Forms.Professional.Design.dll"
```

## Output

- Folder: `NetCore/Gizmox.WebGUI.Forms.Professional.Design/legacy-decompiled`
- Includes:
  - decompilation project file (`legacy-decompiled/Gizmox.WebGUI.Forms.Professional.Design.csproj`)
  - decompiled C# sources
  - decompiled assembly metadata file (`legacy-decompiled/Properties/AssemblyInfo.cs`)