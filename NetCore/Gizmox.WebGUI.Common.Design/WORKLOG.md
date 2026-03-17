# Work Log

## 2026-03-18
- Created NetCore/Gizmox.WebGUI.Common.Design as a new standalone .NET 8 project scaffold.
- Documented legacy assembly analysis and migration constraints.
- Captured initial task backlog with clear separation between runtime needs and deferred full design-support work.
- Honored request to avoid solution changes at this stage.
- Decompiled Sources 4.5.2/Gizmox.WebGUI.Assemblies/bin/4.5.2/Gizmox.WebGUI.Common.Design.dll using ilspycmd into legacy-decompiled.
- Added build exclusion for legacy-decompiled sources so the net8 scaffold remains buildable.
- Logged decompilation workflow and baseline structure for repeatability.
- Triaged decompiled output and current NetCore references into runtime-relevant and deferred buckets.
- Added compatibility shim types for 15 currently referenced legacy type names (serializers, editor, and designer classes).
- Validated scaffold build after shim implementation (`dotnet build` succeeded).
- Verified strong-name identity caveat: full legacy assembly-qualified strings still fail due version/token mismatch.
- Documented triage map and caveat follow-up options in `TRIAGE.md`.
- Normalized live NetCore `Gizmox.WebGUI.Common.Design` attribute strings to simple assembly-qualified names.
- Added project references from Common and Forms to the Common.Design shim project so the assembly is present in consuming builds.
- Rescanned NetCore sources and confirmed the legacy Common.Design public key token now remains only in backup-only content.
- Revalidated `Gizmox.WebGUI.Common` and `Gizmox.WebGUI.Forms`; one initial rebuild failure was a stale terminal process locking the Common.Design output, not a source regression.
