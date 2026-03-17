# Gizmox.WebGUI.Common.Design (.NET 8 Scaffold)

## Purpose
- Track migration work related to the legacy Gizmox.WebGUI.Common.Design assembly.
- Host minimal runtime-safe replacements only when required by runtime behavior.
- Keep full Visual Studio designer parity out of the critical migration path.

## Current Scope
- This project is intentionally lightweight.
- Design-support parity is currently not required.
- Documentation and task tracking live in this folder.

## Files
- Gizmox.WebGUI.Common.Design.csproj: Standalone net8.0-windows project scaffold.
- Compatibility/: Minimal runtime-safe placeholder types for legacy attribute-based resolution.
- legacy-decompiled/: ILSpy decompilation baseline from the legacy .NET Framework DLL.
- DECOMPILATION.md: Reproducible decompilation workflow and structure notes.
- TRIAGE.md: Runtime relevance buckets, shim coverage, and strong-name caveat.
- MIGRATION_NOTES.md: Findings and technical decisions from assembly analysis.
- TASKS.md: Actionable migration backlog.
- WORKLOG.md: Chronological work log entries.
