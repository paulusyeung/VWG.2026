# Gizmox.WebGUI.Forms

## Purpose

This project is the current .NET 8 migration target for the legacy `Gizmox.WebGUI.Forms` assembly.

It is not a direct file-for-file port of `Sources 4.5.2/Gizmox.WebGUI.Forms`. The current NetCore tree is a generated and reorganized runtime-oriented migration baseline.

## Current State

- Target framework: `net8.0-windows`
- Output: class library
- Main project file: `Gizmox.WebGUI.Forms.csproj`
- Source layout: mostly under `Generated/Gizmox/WebGUI/Forms` and `Generated/Gizmox/WebGUI/Virtualization`
- Project references:
  - `../Gizmox.WebGUI.Common/Gizmox.WebGUI.Common.csproj`
  - `../Gizmox.WebGUI.Common.Design/Gizmox.WebGUI.Common.Design.csproj`

Latest migration snapshot recorded on 2026-03-18:

- Legacy compile-file baseline: 487 files
- Exact path match against NetCore mapped sources: 222 files (`45.59%`)
- Name-based legacy filename match: 447 files (`91.79%`)
- Name-missing legacy files: 40
- Latest local build check: success

Reference report:

- `../migration-review-logs/forms-coverage-summary-20260318.txt`
- `LEGACY_NAME_GAPS.md`

## Important Constraints

### 1. File-name parity is not the goal

Many legacy files were split, merged, renamed, or moved during migration. Missing legacy file names do not automatically indicate missing runtime behavior.

Treat these as separate questions:

- Is the legacy type still present?
- Is the runtime behavior still present?
- Is the feature intentionally deferred?

Do not re-add legacy files only to improve apparent coverage numbers.

### 2. ASP host files are intentionally excluded

The project file removes ASP host compile inputs:

- `Generated/Gizmox/WebGUI/Forms/Hosts/Asp*.cs`
- `Generated/Gizmox/WebGUI/Forms/Hosts/Skins/Asp*.cs`

If ASP hosting behavior is needed, that should be handled as a targeted migration task, not a bookkeeping cleanup.

### 3. Designer parity is deferred

`Gizmox.WebGUI.Common.Design` currently provides runtime-safe compatibility shims for referenced design types.

This is enough for current runtime compilation, but it is not full Visual Studio designer parity.

Related docs:

- `../Gizmox.WebGUI.Common.Design/MIGRATION_NOTES.md`
- `../Gizmox.WebGUI.Common.Design/TASKS.md`

## Practical Guidance

When evaluating a missing legacy file name:

1. Check whether the type exists under a different file name.
2. Check whether the surrounding feature already compiles and is used.
3. Only import or recreate a file when a real type or behavior gap is confirmed.
4. Prefer targeted ports over bulk source import.

Low-risk categories usually include:

- aggregate files split into per-type files
- old designer partial layout changes
- SDK-style metadata cleanup such as `AssemblyInfo.cs`

Higher-risk categories usually include:

- ASP host pipeline files
- designer-specific infrastructure
- runtime subsystems where type names changed and behavior still needs verification

## Build

Run from the workspace root:

```powershell
dotnet build .\NetCore\Gizmox.WebGUI.Forms\Gizmox.WebGUI.Forms.csproj -c Debug
```

## Working Notes

Use this section as the running log for future migration decisions.

### 2026-03-18

- The current NetCore Forms project appears sufficient as the main runtime migration baseline.
- Broad legacy source import is not recommended at this point.
- Remaining legacy-name gaps should be handled as targeted verification items, not mass restoration work.
- Priority validation areas if needed:
  - ASP host usage
  - docking helpers/descriptors
  - virtualization management edge cases
  - deferred designer paths

## Next Notes Template

Copy this block for future updates:

```md
### YYYY-MM-DD

- What changed
- What was verified
- What remains open
- Any files or reports worth checking
```