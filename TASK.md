# TASK - .NET 8 Migration Execution Plan

Last updated: 2026-03-17

## Objective
Complete the migration from .NET Framework 4.5.2 to .NET 8 for core libraries under NetCore, with build/test validation and CI reliability.

## Approach
1. Verify before changing.
2. Apply smallest safe fix first (project configuration, workflow paths, target framework alignment).
3. Rebuild and retest immediately after each change.
4. Update project tracking docs to reflect current, measured state.

## Steps Executed (This Session)

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
  - [ ] Server builds (still failing)
- Tests:
  - [x] Common.Tests pass (9/9)
  - [x] BlazorPilot.Tests pass on net8.0 (6/6)
- CI path check:
  - [x] Corrected solution path restores and builds.

## Current Remaining Blockers
1. NetCore/Gizmox.WebGUI.Server
- Large set of syntax errors from decompilation artifacts in Gizmox.WebGUI.Server.decompiled.cs.
- Patterns include malformed escaped tokens, Gen_ artifacts, and unsupported opcode placeholders.

## Next Execution Plan
1. Server syntax pass:
- Apply splitter/cleanup pass for known malformed decompilation patterns.
- Rebuild iteratively until syntax-level errors are gone.

2. Server semantic pass:
- Address remaining API/runtime compatibility issues after syntax parity.

3. Hardening follow-up:
- Keep tests and CI pinned to net8.0 while migration remains in-flight.
- Add explicit skip docs and environment guard notes for Playwright browser dependencies.

4. Documentation hygiene:
- Continue updating project.md and TASK.md after each validated checkpoint.
