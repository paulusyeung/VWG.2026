# Decompilation Workflow

Date: 2026-03-20

## Goal

Create a reproducible source baseline from the legacy Charts assembly for staged migration to .NET 8.

## Source Assembly

- `Sources 4.5.2/Gizmox.WebGUI.Assemblies/bin/4.5.2/Gizmox.WebGUI.Forms.Charts.dll`

## Tooling

- `ilspycmd` 9.1.0.7988

## Command

```powershell
ilspycmd --nested-directories -p -o .\NetCore\Gizmox.WebGUI.Forms.Charts\legacy-decompiled \
  .\Sources 4.5.2\Gizmox.WebGUI.Assemblies\bin\4.5.2\Gizmox.WebGUI.Forms.Charts.dll
```

## Output

- Folder: `NetCore/Gizmox.WebGUI.Forms.Charts/legacy-decompiled`
- Includes:
  - decompilation project file (`legacy-decompiled/Gizmox.WebGUI.Forms.Charts.csproj`)
  - decompiled C# sources (one file per type)
  - legacy embedded resources (`*.png`, `*.resx`)

## Migration Project Note

The standalone migration project is `NetCore/Gizmox.WebGUI.Forms.Charts/Gizmox.WebGUI.Forms.Charts.csproj`.

This root project compiles decompiled sources directly and references migrated NetCore dependencies (`Common`, `Forms`).