# Decompilation Workflow

Date: 2026-03-19

## Goal

Create a reproducible source baseline from the legacy Help assembly for staged migration to .NET 8.

## Source Assembly

- `Sources 4.5.2/Gizmox.WebGUI.Forms.Help/bin/Debug/Gizmox.WebGUI.Forms.Help.dll`

## Tooling

- `ilspycmd` 9.1.0.7988

## Command

```powershell
ilspycmd --nested-directories -p -o .\NetCore\Gizmox.WebGUI.Forms.Help\legacy-decompiled `
  ".\Sources 4.5.2\Gizmox.WebGUI.Forms.Help\bin\Debug\Gizmox.WebGUI.Forms.Help.dll"
```

## Output

- Folder: `NetCore/Gizmox.WebGUI.Forms.Help/legacy-decompiled`
- Includes:
  - decompilation project file (`legacy-decompiled/Gizmox.WebGUI.Forms.Help.csproj`)
  - decompiled C# sources (one file per type)

## Migration Project Note

The standalone migration project is `NetCore/Gizmox.WebGUI.Forms.Help/Gizmox.WebGUI.Forms.Help.csproj`.

This root project compiles decompiled sources directly and references migrated NetCore dependencies (`Common`, `Forms`).