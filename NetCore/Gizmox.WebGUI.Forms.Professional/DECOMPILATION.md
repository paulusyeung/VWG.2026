# Decompilation Workflow

Date: 2026-03-18

## Goal

Create a reproducible source baseline from the legacy Professional assembly for staged migration to .NET 8.

## Source Assembly

- `Sources 4.5.2/Gizmox.WebGUI.Assemblies/bin/4.5.2/Gizmox.WebGUI.Forms.Professional.dll`

## Tooling

- `ilspycmd` 9.1.0.7988

## Command

```powershell
ilspycmd --nested-directories -p -o .\NetCore\Gizmox.WebGUI.Forms.Professional\legacy-decompiled \
  .\Sources 4.5.2\Gizmox.WebGUI.Assemblies\bin\4.5.2\Gizmox.WebGUI.Forms.Professional.dll
```

## Output

- Folder: `NetCore/Gizmox.WebGUI.Forms.Professional/legacy-decompiled`
- Includes:
  - decompilation project file (`legacy-decompiled/Gizmox.WebGUI.Forms.Professional.csproj`)
  - decompiled C# sources (one file per type)
  - legacy embedded resources (`*.bmp`, `*.png`, `*.resx`)

## Migration Project Note

The standalone migration project is `NetCore/Gizmox.WebGUI.Forms.Professional/Gizmox.WebGUI.Forms.Professional.csproj`.

This root project compiles decompiled sources directly and references migrated NetCore dependencies (`Common`, `Forms`) plus `ZedGraph`.
