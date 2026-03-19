# Decompilation Workflow

Date: 2026-03-19

## Goal

Create a reproducible source baseline from the legacy Office.Design assembly for staged migration to .NET 8.

## Source Assembly

- `Sources 4.5.2/Gizmox.WebGUI.Assemblies/bin/4.5.2/Gizmox.WebGUI.Forms.Office.Design.dll`

## Tooling

- `ilspycmd` 9.1.0.7988

## Command

```powershell
ilspycmd --nested-directories -p -o .\NetCore\Gizmox.WebGUI.Forms.Office.Design\legacy-decompiled `
  ".\Sources 4.5.2\Gizmox.WebGUI.Assemblies\bin\4.5.2\Gizmox.WebGUI.Forms.Office.Design.dll"
```

## Output

- Folder: `NetCore/Gizmox.WebGUI.Forms.Office.Design/legacy-decompiled`
- Includes:
  - decompilation project file (`legacy-decompiled/Gizmox.WebGUI.Forms.Office.Design.csproj`)
  - decompiled C# sources
  - decompiled assembly metadata file (`legacy-decompiled/Properties/AssemblyInfo.cs`)
