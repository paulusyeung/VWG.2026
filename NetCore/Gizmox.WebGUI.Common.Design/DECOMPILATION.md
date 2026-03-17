# Decompilation Workflow

Date: 2026-03-18

## Goal
Create a reproducible source baseline from the legacy assembly to drive staged migration work.

## Source Assembly
- Sources 4.5.2/Gizmox.WebGUI.Assemblies/bin/4.5.2/Gizmox.WebGUI.Common.Design.dll

## Tooling
- ilspycmd 9.1.0.7988

## Command
powershell
ilspycmd --nested-directories -p -o .\NetCore\Gizmox.WebGUI.Common.Design\legacy-decompiled \
  .\Sources 4.5.2\Gizmox.WebGUI.Assemblies\bin\4.5.2\Gizmox.WebGUI.Common.Design.dll

## Output
- Folder: NetCore/Gizmox.WebGUI.Common.Design/legacy-decompiled
- Includes decompilation project file and one source file per type.
- Contains an obfuscated namespace bucket A with helper types.

## Important Build Note
- The scaffold project excludes legacy-decompiled/**/*.cs from compilation.
- This keeps the net8 scaffold buildable while allowing incremental migration and manual cleanup.

## Next Steps
1. Classify decompiled files by runtime relevance.
2. Prioritize files tied to runtime editor/property behavior.
3. Port minimal required logic into clean net8-compatible source files.
4. Add runtime tests before broad replacement.
