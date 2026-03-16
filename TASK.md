# TASK - .NET 8 Migration Execution Plan

Last updated: 2026-03-17

## Objective
Complete the migration from .NET Framework 4.5.2 to .NET 8 for core libraries under NetCore, with build/test validation and CI reliability.

## Approach
1. Verify before changing.
2. Apply smallest safe fix first (project configuration, workflow paths, target framework alignment).
3. Rebuild and retest immediately after each change.
4. Update project tracking docs to reflect current, measured state.

## Steps Executed (Current Checkpoint)

### 1) Baseline Validation
- Ran fresh build checks for core libraries:
  - Gizmox.WebGUI.Common
  - Gizmox.WebGUI.Forms
  - Gizmox.WebGUI.Client
  - Gizmox.WebGUI.Converters
  - Gizmox.WebGUI.Server
- Ran test projects:
  - Gizmox.WebGUI.Common.Tests
  - Gizmox.WebGUI.BlazorPilot.Tests (with PLAYWRIGHT_SKIP=true)
- Verified GitHub workflow restore/build path used in dotnet-test.yml.

### 2) Quick-Win Fixes Applied
- Updated workflow solution paths in .github/workflows/dotnet-test.yml:
  - NetCore/Gizmox.WebGUI.BlazorPilot.sln
  -> NetCore/Gizmox.WebGUI.BlazorPilot/Gizmox.WebGUI.BlazorPilot.sln
- Retargeted NetCore/Gizmox.WebGUI.BlazorPilot.Tests/Gizmox.WebGUI.BlazorPilot.Tests.csproj:
  - net9.0 -> net8.0

### 3) Client Compile Unblock (Option 1)
- Reduced Client compiler errors from 33 to 0.
- Aligned interface signatures and generic types in Context implementation.
- Fixed GatewayRequest abstract member shape mismatch.
- Added legacy WinForms compatibility shims in:
  - NetCore/Gizmox.WebGUI.Client/Generated/LegacyWinFormsShims.cs
- Added missing shim members used by generated code:
  - ContextMenu.Show(...)
  - MenuItem.RadioCheck
- Updated controller paths where legacy members are absent on modern WinForms (temporary no-op where needed).

### 4) Converters Alignment and Re-Fix
- Restored Converters TFM compatibility with Common:
  - NetCore/Gizmox.WebGUI.Converters/Gizmox.WebGUI.Converters.csproj
  - net8.0 -> net8.0-windows
- Removed legacy assembly attributes again from:
  - NetCore/Gizmox.WebGUI.Converters/Gizmox.WebGUI.Converters.decompiled.cs
  to resolve duplicate AssemblyInfo/TargetFramework errors.

### 5) Re-Validation Results
- Build status:
  - [x] Common builds
  - [x] Forms builds
  - [x] Converters builds
  - [x] Client builds
  - [x] Server builds
- Tests:
  - [x] Common.Tests pass (9/9)
  - [x] BlazorPilot.Tests pass on net8.0 (6/6)
- CI path check:
  - [x] Corrected solution path restores and builds.

### 6) Server Compile Unblock Completed
- Reduced Server compile errors from large decompilation-artifact sets to 0.
- Completed recurring decompiled-source fixes in `Gizmox.WebGUI.Server.decompiled.cs`:
  - generic collection artifact cleanup,
  - explicit cast fixes for decompiled object flows,
  - event/provider signature and type alignment,
  - async handler fallback completion path,
  - process-statistics fallback using `System.Diagnostics.Process`.
- Expanded/adjusted Common shim support used by Server:
  - `HttpException` overload/API parity,
  - `CustomErrorsSection`/`CustomError` stubs,
  - `HttpSessionStateContainer` stub,
  - `HttpContext.Current` setter visibility for cross-assembly usage.
- Removed duplicate HttpUtility shim from Common to resolve type ambiguity with framework `System.Web.HttpUtility`.

### 7) Warning Reduction Pass #1 (Nullable + Obsolete Hotspots)
- Rebuilt `NetCore/Gizmox.WebGUI.Server/Gizmox.WebGUI.Server.csproj` and re-baselined warnings.
- Reduced Server warning count from `990` to `896` (delta `-94`) while preserving `ERROR_COUNT=0`.
- Eliminated targeted warning categories in this pass:
  - `NETSDK1080` -> removed redundant `Microsoft.AspNetCore.App` package reference.
  - `CS0618` -> replaced `HttpUtility.UrlEncodeUnicode` with `HttpUtility.UrlEncode`.
  - `SYSLIB0006` -> removed `Thread.Abort()` usage in stop/shutdown paths.
  - `CA2200` -> replaced `throw ex;` patterns with stack-preserving rethrow paths.
  - `CS8765` / `CS8767` -> aligned nullability on async interface/override signatures.
  - `CS8632` -> enabled nullable annotation context in shim/generated files that already use nullable annotations.

## Current Remaining Blockers
1. No compile blockers for the five core libraries.
2. Warning backlog remains (mostly high-volume nullable flow warnings: `CS8618`, `CS8600`, `CS8603`, `CS8625`, `CS8604`).
3. Runtime parity still needs validation in Server request paths and legacy feature branches.

## Next Execution Plan
1. Run full NetCore solution-level build/test validation to confirm integrated stability.

2. Prioritize warning reduction by category:
- nullability correctness,
- obsolete runtime API usage (high-priority hotspots from pass #1 completed),
- decompiler residual cleanup where low risk.

3. Continue hardening:
- keep tests/CI pinned to net8.0,
- preserve Playwright skip guard documentation,
- validate Server runtime behavior beyond compile parity.

4. Continue documentation hygiene:
- update `PROJECT.md` and `TASK.md` after each validated checkpoint.
