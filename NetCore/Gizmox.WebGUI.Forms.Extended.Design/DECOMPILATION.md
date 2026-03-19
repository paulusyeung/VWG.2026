# Decompilation Workflow

Date: 2026-03-19

## Goal

Create a reproducible source baseline from the legacy Extended.Design assembly for staged migration to .NET 8.

## Source Assembly

- `Sources 4.5.2/Gizmox.WebGUI.Forms.Extended.Design/bin/Gizmox.WebGUI.Forms.Extended.Design.dll`

## Tooling

- `ilspycmd` 9.1.0.7988

## Command

```powershell
ilspycmd --nested-directories -p -o .\NetCore\Gizmox.WebGUI.Forms.Extended.Design\legacy-decompiled `
  ".\Sources 4.5.2\Gizmox.WebGUI.Forms.Extended.Design\bin\Gizmox.WebGUI.Forms.Extended.Design.dll"
```

## Output

- Folder: `NetCore/Gizmox.WebGUI.Forms.Extended.Design/legacy-decompiled`
- Includes:
  - decompilation project file (`legacy-decompiled/Gizmox.WebGUI.Forms.Extended.Design.csproj`)
  - decompiled C# sources
  - decompiled assembly metadata file (`legacy-decompiled/Properties/AssemblyInfo.cs`)