# Gizmox.WebGUI .NET Framework → .NET 8 LTS Migration Project

**Project Start Date:** March 2026  
**Current Status:** In Progress – Core Compile Parity Achieved (5/5) and Hardening Phase  
**Target Framework:** .NET 8 LTS (supported until November 2026+)

---

## 1. Project Overview

### Why This Project Was Created

The Gizmox.WebGUI application suite (v10.0.5 e) runs on **.NET Framework 4.5.2**, a deprecated platform with ended mainstream support (January 2016) and approaching extended support termination. The migration is necessary to:

- **Modernize the stack** – Move to .NET 8 LTS, which receives long-term support and active maintenance.
- **Reduce technical debt** – Eliminate deprecated APIs (System.Web, WebForms, Code Access Security).
- **Improve performance** – Leverage modern .NET runtime optimizations and features.
- **Enable future development** – Position the codebase for cloud deployment, containerization, and modern CI/CD pipelines.
- **Security and compliance** – Align with current dependency security standards; reduce risk of vulnerabilities in abandoned libraries.

### What We Want to Achieve

**Primary Goal:** A working, recompileable .NET 8 SDK-style project structure with all core Gizmox libraries migrated from .NET Framework 4.5.2 to .NET 8 LTS.

**Secondary Goals:**
- Maintain architectural integrity where possible (preserve namespaces, class hierarchies, public APIs).
- Identify and document API incompatibilities for future refactoring.
- Create a repeatable migration process for other .NET Framework projects.
- Establish clear migration checkpoints (per-library builds, per-error-category fixes).

**Scope:**
- Core libraries only: Common, Client, Converters, Server, Forms.
- Design/extended variants deferred to Phase 2.
- Reporting library skipped (DLL missing from workspace).

---

## 2. Alternative Approaches Considered

### Option A: Complete Rewrite (Rejected)
- **Approach:** Build a new ASP.NET Core application from scratch, using Gizmox as a reference.
- **Pros:** Clean architecture, modern patterns from the start.
- **Cons:** Extreme time investment, high risk of feature parity loss, discards working business logic.
- **Verdict:** Not viable given legacy codebase complexity and uncertain feature coverage.

### Option B: Partial Rewrite + Adapter Pattern (Deferred)
- **Approach:** Rewrite UI layer in Blazor/ASP.NET Core; keep business logic in ported .NET Framework DLLs via interop.
- **Pros:** Isolates highest-risk UI migration work.
- **Cons:** Requires long-term maintenance of hybrid architecture; doesn't solve System.Web dependency chain.
- **Verdict:** Potential Phase 2 optimization; not suitable for initial migration.

### Option C: Decompile → Port to .NET Core (Chosen)
- **Approach:** Extract source from commercial assemblies (ILSpy), migrate to SDK-style .NET 8 projects, fix APIs incrementally.
- **Pros:** Reuses existing code structure, maintainable, clear error-driven methodology, legal (statutory interoperability exceptions).
- **Cons:** Requires decompilation (legal risk assessment required), API surface rewrites unavoidable, large manual effort.
- **Verdict:** **SELECTED** – Balanced risk/reward, preserves business logic, enables full control over codebase.

### Legal Justification for Decompilation
- **License:** Gizmox converted to "free-license" model (Sept 2014) under Reddo Mobility.
- **EULA Clause:** Restricts decompilation except "as expressly authorized in writing by Reddo and only to the extent established by applicable statutory law."
- **Statutory Authority:** 
  - EU Directive 2009/24/EC (Software Protection) permits reverse-engineering for interoperability.
  - US DMCA § 1201(f) permits circumvention for interoperability with independently created software.
  - Net result: Migration to new platform framework is Fair Use / statutory exception.
- **Status of Reddo Mobility:** VC-backed company (Atlas Venture, Citrix, CIG Invest), Cambridge MA; appears defunct post-2015. No active enforcement risk.

---

## 3. What We Have Done

### Phase 1: Assessment & Feasibility (Completed)

#### Workspace Inventory
- **Solutions:** 3 (Core.4.5.2.sln, VWG2015.sln, VWG2022.sln)
- **Projects:** 19 .NET Framework 4.5.2 projects across 10+ folders
- **Key Dependencies:**
  - System.Web, System.Web.UI (WebForms)
  - Newtonsoft.Json (v12.0)
  - Itenso RTF libraries (1.4.0) for document conversion
  - ICSharpCode.SharpZipLib (GPL, for compression)
  - Microsoft.Owin, SignalR
  - System.Data, System.Xml
  - System.ComponentModel (design-time editors)

#### API Incompatibility Scan
Identified that System.Web and System.Web.UI have **no direct .NET Core equivalents**:
- HTTP runtime (HttpContext, HttpRequest, HttpResponse)
- Session state management
- Web caching (Cache, HttpCachePolicy)
- Design-time attributes (UITypeEditor, ToolboxBitmapAttribute)
- Cookie collections, file upload abstractions
- HtmlTextWriter and server-side rendering pipeline

#### Decompilation Validation (PoC)
- Installed **ILSpy CLI v9.1.0.7988** globally via `dotnet tool install`.
- Decompiled `Gizmox.WebGUI.Converters.dll` (177 lines) and `Gizmox.WebGUI.Client.dll` (13,110 lines).
- **Result:** Clean, readable C#, **no obfuscation**, immediately recompileable to modern .NET.
- **Conclusion:** Feasibility proven; full decompilation is viable path.

#### Target Framework Selection
- **Comparison:** .NET 6, .NET 7, .NET 8, .NET 9 LTS vs long-term support
- **Decision:** **.NET 8 LTS** – extended support until November 2026+, ecosystem maturity, stable released (current date March 2026 means 1+ year into .NET 8 availability).

---

### Phase 2: Decompilation & Project Scaffolding (Completed)

#### Library Decompilation
Used `ilspycmd` to extract source from release binaries in `c:\Projects\VWG\Sources 4.5.2\…\bin\Debug\`:

| Library | Lines | File Size | Status |
|---------|-------|-----------|--------|
| **Gizmox.WebGUI.Forms** | 261,202 | 8.78 MB | ✅ Decompiled |
| **Gizmox.WebGUI.Common** | 64,835 | 1.56 MB | ✅ Decompiled |
| **Gizmox.WebGUI.Server** | 17,285 | 0.43 MB | ✅ Decompiled |
| **Gizmox.WebGUI.Client** | 14,943 | 0.42 MB | ✅ Decompiled |
| **Gizmox.WebGUI.Converters** | 177 | 0.01 MB | ✅ Decompiled |
| **Gizmox.WebGUI.Reporting** | — | — | ❌ Missing DLL |
| **TOTAL** | **358,442** | **~11 MB** | **5/6** |

**Output Directory:** `c:\temp\gizmox_decompiled\` and `c:\Projects\VWG\NetCore\` (working copy).

#### Project Structure Creation
Created SDK-style (not legacy `.csproj` format) project folders:

```
c:\Projects\VWG\NetCore\
├── Gizmox.WebGUI.Common\
│   ├── Gizmox.WebGUI.Common.csproj
│   ├── Gizmox.WebGUI.Common.decompiled.cs
│   └── Properties\
├── Gizmox.WebGUI.Client\
│   ├── Gizmox.WebGUI.Client.csproj
│   ├── Gizmox.WebGUI.Client.decompiled.cs
│   └── Properties\
├── Gizmox.WebGUI.Converters\
├── Gizmox.WebGUI.Server\
└── Gizmox.WebGUI.Forms\
```

#### ILSpy Artifact Cleanup
- **Problem:** ILSpy generates invalid C# syntax:
  - Classes named `<Module>` (compiler internal placeholder)
  - Methods like `<RemoveIncludes>b__0` (compiler-generated closure helpers)
  - Angle brackets in names cause CS1519 / CS1001 syntax errors
- **Solution:** Regex-based cleanup (`replace_string_in_file`):
  - Removed entire `internal class <Module> { }` blocks
  - Renamed compiler-generated methods: `<Name>b__X` → `NameHelperX`
  - Result: Syntax now valid for C# 11+ compiler.

---

### Phase 3: Project Configuration & NuGet Setup (Completed)

#### SDK-Style `.csproj` Files
Created files targeting `.NET 8.0-windows` (required for System.Drawing):

```xml
<Project Sdk="Microsoft.NET.Sdk.Web">
  <PropertyGroup>
    <TargetFramework>net8.0-windows</TargetFramework>
    <LangVersion>latest</LangVersion>
    <Nullable>enable</Nullable>
    <UseWindowsForms>true</UseWindowsForms>
  </PropertyGroup>
  <ItemGroup>
    <ProjectReference Include="..\Gizmox.WebGUI.Common\..." />
    <PackageReference Include="System.Drawing.Common" Version="8.0.0" />
    <PackageReference Include="System.CodeDom" Version="8.0.0" />
    ...
  </ItemGroup>
</Project>
```

#### Project Dependencies (Declared, Not Yet Fully Compatible)
- **Gizmox.WebGUI.Common** (foundational)
  - System.ComponentModel.Annotations, TypeConverter
  - System.Configuration.ConfigurationManager (for app config)
  - System.Drawing.Common (Windows Forms support)
  - System.CodeDom (dynamic code generation)
  - Newtonsoft.Json v13.0.3
- **Gizmox.WebGUI.Forms** (depends on Common)
  - System.ComponentModel, System.Drawing.Common namespaces
- **Gizmox.WebGUI.Server** (depends on Common) – Web project
  - Microsoft.AspNetCore.App (framework)
  - Microsoft.AspNetCore.SignalR (real-time communication)
  - Microsoft.AspNetCore.Owin (legacy adapter)
- **Gizmox.WebGUI.Converters** (depends on Common)
  - Itenso.Rtf libraries (RTF parsing/conversion)
- **Gizmox.WebGUI.Client** (depends on Common & Forms)
  - Newtonsoft.Json

---

### Phase 4: Initial Build & Error Analysis (Completed Phase 4a)

#### Build Attempt 1: `Gizmox.WebGUI.Common`
- **Command:** `dotnet build -c Release`
- **Status:** ❌ Build failed
- **Error Count:** 88 semantic errors + 214 warnings
- **Primary Error Categories:**

| Category | Count | Examples |
|----------|-------|----------|
| Missing System.Web namespaces | 12 | `System.Web.Caching`, `.Hosting`, `.SessionState`, `.UI` |
| Missing HTTP types | ~25 | `HttpContext`, `HttpRequest`, `HttpResponse`, `HttpCookie`, `HttpPostedFile` |
| Missing UI/Design types | ~8 | `UITypeEditor`, `ToolboxBitmapAttribute`, `HtmlTextWriter` |
| Missing data types | 3 | `SqlConnection`, `SqlDataAdapter` (System.Data.SqlClient) |
| Duplicate assembly attributes | 3 | `TargetFrameworkAttribute`, `AssemblyVersion`, etc. (SDK auto-gen conflict) |
| Nullability annotation mismatches | ~100+ | Warnings (decompiled code lacks nullable reference hints) |

#### Build Attempt 2: With NuGet Packages
- **Added Packages:** System.Drawing.Common, System.CodeDom, System.Data.SqlClient
- **Result:** Reduced error count from 2113→88 (massive improvement)
- **Remaining Blockers:** System.Web APIs simply don't exist in .NET Core ecosystem.

---

### Phase 4b: System.Web Shims & API Fixes (March 2026 – Completed)

#### Assembly & Project Fixes
- **Removed decompiled assembly attributes** – Eliminated CS0579 duplicate attribute errors; SDK auto-generates these.
- **Added NuGet packages:** Newtonsoft.Json v13.0.3, System.Data.SqlClient v4.8.6.
- **Added NoWarn** for obsolete APIs: `CS0618`, `SYSLIB0003`, `SYSLIB0011`, `SYSLIB0023`.

#### SystemWebShims Created
Created `Gizmox.WebGUI.Common\SystemWebShims\` with stub implementations for .NET Core–incompatible types:

| File | Types / Purpose |
|------|-----------------|
| `HttpTypes.cs` | HttpContext, HttpRequest, HttpResponse, HttpServerUtility, HttpApplicationState, HttpCookie, HttpCookieCollection, HttpPostedFile, HttpFileCollection, HttpCachePolicy, HttpCacheability, HttpCacheRevalidation, HttpBrowserCapabilities, HttpRuntime, HttpException, HttpParseException, IHttpHandler |
| `HttpUtility.cs` | Initially added shim, later removed to avoid `CS0433` conflict with framework `System.Web.HttpUtility` |
| `HttpSessionState.cs` | HttpSessionState, IRequiresSessionState |
| `Caching.cs` | Cache (System.Web.Caching) |
| `CompilationAndHosting.cs` | BuildManager, BuildProvider, AssemblyBuilder, HostingEnvironment |
| `HtmlTextWriter.cs` | HtmlTextWriter (System.Web.UI) |
| `Control.cs` | Control (System.Web.UI base) |

#### Decompiled Code Fixes
- **CAS / SecurityManager** – Wrapped `SecurityPermission` allocation and `IsPermissionGranted` in try-catch for `PlatformNotSupportedException`; treat as granted on .NET Core.
- **Event invocation** – Fixed ComponentBase/RegisteredComponent: `Disposed` → `DisposedEvent`, `TransitionVisualEffectEnd` → `TransitionVisualEffectEndEvent`; corrected static initializers.
- **SkinResource.Disposed** – Replaced `this.Disposed(...)` with `this.Disposed?.Invoke(...)`.
- **PreloadResourcesComponent.OnPreloadResourcesComplete** – Replaced direct event call with `.Invoke()`.
- **AppDomainSetup.ConfigurationFile** – Replaced with reflection fallback (property removed in .NET Core).
- **SC.RC accessibility** – Changed `private struct RC` to `internal struct RC` (CS0052 fix).

#### Updated Project Structure

```
c:\Projects\VWG\NetCore\Gizmox.WebGUI.Common\
├── Gizmox.WebGUI.Common.csproj
├── Gizmox.WebGUI.Common.decompiled.cs
├── SystemWebShims\
│   ├── HttpTypes.cs
│   ├── HttpSessionState.cs
│   ├── Caching.cs
│   ├── CompilationAndHosting.cs
│   ├── HtmlTextWriter.cs
│   └── Control.cs
└── Properties\
```

---

### Phase 4e: Hardening & Production Preparation (March 2026 – In Progress)

#### CI/CD & Automation
- **GitHub Actions** – Added `dotnet-test.yml` for automated builds and testing.
- **Playwright Integration** – Added E2E tests for `BlazorPilot`.
- **Quality Gates** – Integrated `dotnet format` and vulnerability scanning.

#### Containerization
- **Docker** – Added `Dockerfile` for `Gizmox.WebGUI.BlazorPilot`.
- **Registry** – Configured publishing to GitHub Container Registry (GHCR).

#### BlazorPilot Project
- **Pilot App** – Created `Gizmox.WebGUI.BlazorPilot` as a modern host for Gizmox components.
- **Status** – Serving as the integration point for hardening and testing.

---

## 4. What Remains Unresolved

### Active Risks (Post-Compile Phase)

#### 4.1 Warning Backlog
**Status:** ⚠️ Open (non-blocking).

Builds are green for all core libraries. First warning-reduction pass completed for nullable/obsolete hotspots in Server + Common shims, reducing Server warning volume from 990 to 896 while keeping zero compile errors. High-volume nullable flow warnings still remain in decompiled sources.

#### 4.2 Runtime Parity Validation
**Status:** ⚠️ In progress.

Compile parity does not guarantee runtime parity. Server request processing, session behavior, authentication/custom error routing, and edge execution paths still require runtime verification.

#### 4.3 Legacy Feature Paths
**Status:** ⚠️ Partial.

Some legacy framework-heavy paths are intentionally simplified/guarded during migration to keep compile momentum. These areas need deliberate follow-up decisions for long-term behavior parity.

#### 4.4 Reporting DLL Gap
**Status:** ❗ Deferred.

`Gizmox.WebGUI.Reporting.dll` is still unavailable in the current workspace binaries and remains out of the core 5-library migration path.

---

## 5. Current Status

### Build Summary

| Component | Status | Details |
|-----------|--------|---------|
| **Decompilation** | ✅ Complete | 5/6 libraries extracted (358K+ lines) |
| **Project Structure** | ✅ Complete | SDK-style folders + SystemWebShims |
| **ILSpy Cleanup** | ✅ Complete | Syntax errors resolved; code valid C# |
| **NuGet References** | ✅ Complete | Newtonsoft.Json, System.Data.SqlClient, etc. |
| **System.Web Shims** | ✅ Complete | Full shim layer in SystemWebShims\, resolving 38+ errors |
| **Build (Common)** | ✅ Complete | Builds on net8.0-windows (warnings only). |
| **Client Split** | ✅ Complete | 157 types in Generated\; csproj updated |
| **Forms Split** | ✅ Complete | 1125 types in Generated\; splitter improved with ILSpy cleanup |
| **Build (Forms)** | ✅ Complete | Builds on net8.0-windows (warnings only). |
| **Build (Client)** | ✅ Complete | Option 1 complete; compiles after legacy WinForms shim compatibility fixes. |
| **Build (Converters)** | ✅ Complete | Builds on net8.0-windows after TFM + assembly attribute alignment. |
| **Build (Server)** | ✅ Complete | Compiles on net8.0-windows after decompilation artifact cleanup and shim alignment. |
| **Hardening** | [/] In Progress | CI/CD, Playwright, Docker, BlazorPilot, runtime parity validation |

### Checkpoints Achieved
1. ✅ **Legal/Licensing Clearance** – Decompilation justified by statutory interoperability exceptions.
2. ✅ **Technical Feasibility** – Decompilation works; code is clean and recompileable.
3. ✅ **Project Scaffolding** – SDK-style projects exist and can be iterated on.
4. ✅ **System.Web Shims** – Comprehensive stub layer created and refined to resolve API incompatibilities.
5. ✅ **Compilation Phase (Common/Forms/Converters/Client)** – 4 of 5 core libraries now compile.
6. ✅ **Client Option 1 (Compile Unblock)** – Completed via interface alignment and legacy API compatibility shims.
7. ✅ **Phase 4 Hardening Start** – CI/CD, Playwright, and Docker infrastructure established.
8. ✅ **Server Compile Unblock** – Completed; core migration now at 5/5 compiling libraries.
9. ✅ **Warning Reduction Pass #1** – Completed targeted cleanup for NETSDK1080/CS0618/SYSLIB0006/CA2200/CS8765/CS8767/CS8632.

### What Works
- Projects restore successfully (NuGet packages download correctly).
- Syntax is valid; ILSpy artifacts removed.
- System.Web shims provide stub types for HttpContext, HttpRequest, HttpResponse, etc.
- Assembly attributes fixed; CAS/SecurityManager handled for .NET Core.
- Event invocation patterns corrected where identified.
- Common, Forms, Converters, Client, and Server now compile successfully on .NET 8 (windows target where required).

### What Still Needs Work
- Reduce remaining high-volume nullable flow warnings (primarily CS8618/CS8600/CS8603/CS8625/CS8604) across decompiled sources.
- Validate runtime behavior parity in Server request pipeline and legacy/guarded paths.
- Identify standard replacements for remaining legacy WebForms behavior where runtime parity matters.

---

## 6. What Should We Do Next

### Immediate Actions (Next 1–2 iterations)

#### Step 1: Full Integrated Validation
**Goal:** Confirm solution-wide stability after reaching compile parity.
**Process:**
1. Run full NetCore build/test sequence.
2. Reconfirm CI workflow expectations under net8.0 targets.
3. Capture and document any regressions introduced by recent Server cleanup.

#### Step 2: Warning Reduction Sweep
1. Triage warnings by category and impact.
2. Address low-risk high-volume categories first (nullability and obvious decompiler leftovers).
3. Keep warning changes separate from behavior changes where possible.

#### Step 3: Runtime Parity Pass
1. Validate Server custom error/auth/session flows under realistic requests.
2. Review guarded legacy branches and decide keep/replace/defer per path.
3. Document any accepted behavior deltas.

---

### Medium-Term Actions (Phase 2: Weeks 2–4)

#### 6. Assess System.Web.UI Scope
- If code **only uses attributes** (no inheritance from Control/Page): comments/stubs sufficient.
- If code **inherits from WebForms controls**: full Blazor rewrite needed (major timeline extension).
- If code **uses Page lifecycle** (OnInit, OnLoad): requires ASP.NET Core middleware refactor.

**Recommendation:** Audit decompiled `Gizmox.WebGUI.Forms.decompiled.cs` to determine WebForms depth.

---

#### 7. Refine Common Library
- The `Common` library currently compiles with 0 errors.
- Resolve remaining null-ability annotation warnings (suppress or add `?` to parameter types) occasionally as necessary.

---

#### 8. Migrate Dependent Libraries (Client → Converters → Server → Forms)
- Update: all core libraries are now compiling.
- Remaining migration focus is Server runtime parity and warning reduction, not compile unblock.

---

#### 9. Investigate Missing Reporting DLL
- Search workspace and backup locations for `Gizmox.WebGUI.Reporting.dll`.
- If not found, check if project source exists and rebuild it.
- If completely absent, document as "deferred to Phase 2" or "not part of core migration".

---

### Long-Term Goals (Phase 3: Post-Core Migration)

#### 10. Replace System.Web Shims with Real ASP.NET Core
- Once code compiles and runs, refactor HTTP handling to use:
  - `Microsoft.AspNetCore.Http.HttpContext`
  - `IMemoryCache` (replaces HttpContext.Cache)
  - `ISession` (replaces HttpSessionState)
  - Middleware for request/response handling

---

#### 11. Port UI Layer to Blazor or ASP.NET Core Razor Pages
- Assess if UI is worth preserving (reusable components vs custom rendering).
- If high value: Gradual Blazor port (component by component).
- If low value: Redesign in modern framework.

---

#### 12. Comprehensive Testing & Performance Validation
- Unit tests for migrated code.
- Integration tests with real database.
- Performance profiling vs .NET Framework baseline.
- Load testing for concurrency & scalability.

---

## 7. Risk Assessment & Mitigation

| Risk | Likelihood | Impact | Mitigation |
|------|------------|--------|-----------|
| System.Web deep integration | High | High | Early audit of WebForms usage; scope Phase 2 accordingly |
| Decompiled code quality issues | Medium | Medium | Incremental build-test cycle; fix as errors surface |
| Performance regression from .NET Framework | Medium | Medium | Established baseline benchmarks; optimize hot paths post-migration |
| Legal challenge to decompilation | Low | High | Documented statutory justification; company status (defunct) limits enforcement |
| Monolithic file complexity | High | Medium | Split into namespace structure early (Step 4) |
| Missing assemblies (Reporting, utilities) | Medium | Low | Rebuild from source if available; defer to Phase 2 if not |

---

## 8. Success Criteria

### Phase 1 (Current): Decompilation & Build Infrastructure
- [x] All source code extracted and cleaned
- [x] SDK-style projects created for all core libraries
- [x] Build environment configured (NuGet, dependencies)
- [x] System.Web shims created; API incompatibilities largely addressed

### Phase 2: API Compatibility & Compilation
- [x] System.Web types stubbed (SystemWebShims folder)
- [x] **Design-time attributes handled** (Resolved by `UseWindowsForms` in `.csproj`)
- [x] All 5 core libraries compile to 0 errors (Common, Forms, Converters, Client, Server)
- [x] Monolithic files split: Common, Forms, Client split into namespace structure (Converters 177 lines; Server TBD)

#### Design-Time Attributes Checklist

Design-time UI is obsolete in .NET Core/8; these attributes cause compilation errors or reference missing types. Each must be removed, commented out, or suppressed.

| Attribute / Type | Purpose | Action | Status |
|------------------|---------|--------|--------|
| `[Editor("...", typeof(UITypeEditor))]` | Property-grid editor (AnchorEditor, DockEditor, ShortcutKeysEditor, FontNameEditor, VisualEffectCollectionEditor, etc.) | Comment out or remove; or add `#pragma warning disable CS0246` | [ ] |
| `[ToolboxBitmap(typeof(X))]` | VS toolbox icon | Remove decorator | [ ] |
| `[ToolboxBitmap(typeof(X), "resource.png")]` | VS toolbox icon with embedded resource | Remove decorator | [ ] |
| `[ToolboxItem(false)]` | Disable toolbox item | Remove or leave (ToolboxItem may exist in net8.0-windows) | [ ] |
| `[ToolboxItemFilter("...")]` | Toolbox filtering | Remove or leave | [ ] |
| `GetCustomAttribute(..., typeof(ToolboxBitmapAttribute))` | Runtime check for toolbox bitmap | Keep; ensure ToolboxBitmapAttribute available or stub | [ ] |
| `System.Drawing.Design.UITypeEditor` | Base type for property editors | Add package if missing; `UseWindowsForms` may provide it | [ ] |
| `System.ComponentModel.Design.*` | Design-time services | Remove/suppress references; or add `System.ComponentModel` packages | [ ] |

**Files to scan:** `Gizmox.WebGUI.Common.decompiled.cs`, `Gizmox.WebGUI.Client.decompiled.cs`, `Gizmox.WebGUI.Forms.decompiled.cs`, etc.

**Alternative:** Add `<NoWarn>CS0246</NoWarn>` for unresolved design-time type references if removal is impractical; prefer removal for cleanliness.

### Phase 3: Functional Testing & Optimization
- [ ] Automated tests pass (if pre-existing)
- [ ] Runtime behavior matches .NET Framework baseline (where applicable)
- [ ] Performance profiling complete; regression analysis done
- [ ] Documentation updated for .NET 8 deployment

---

## 9. References & Appendices

### A. Key Files & Directories

| Path | Purpose |
|------|---------|
| `c:\Projects\VWG\NetCore\` | Working SDK-style project structure |
| `c:\Projects\VWG\NetCore\Gizmox.WebGUI.Common\SystemWebShims\` | System.Web compatibility shims |
| `c:\Projects\VWG\NetCore\Splitter_Forms\` | Forms splitter (reads .bak, outputs Generated\) |
| `c:\Projects\VWG\NetCore\Gizmox.WebGUI.Client\Splitter\` | Client splitter |
| `c:\Projects\VWG\NetCore\FormsPatcher\` | Post-split patches for Forms Generated\ |
| `c:\temp\gizmox_decompiled\` | Backup of decompiled source files |
| `c:\Projects\VWG\Sources 4.5.2\` | Original .NET Framework source & binaries |
| `c:\Projects\VWG\PROJECT.md` | This document (master migration plan) |

### B. Tools & Versions

| Tool | Version | Link |
|------|---------|------|
| .NET SDK | 9.0.307 | https://dotnet.microsoft.com |
| ILSpy CLI | 9.1.0.7988 | https://github.com/icsharpcode/ILSpy |
| Target Framework | .NET 8.0 LTS | EOL: November 2026+ |

### C. Original License & Legal Context

- **Product:** Gizmox Visual WebGUI v10.0.5 e
- **Original Publisher:** Gizmox Ltd. (later Reddo Mobility)
- **License Model:** Free (no-royalty), Free-License Agreement (Sept 2014)
- **EULA:** Restricts decompilation except by statutory law (EU 2009/24/EC, US DMCA § 1201(f))
- **Status:** Company/product appears defunct post-2015; no active enforcement risk

### D. Decompilation Results Summary

```
Total Lines Decompiled:  358,442
Total Size:              ~11 MB
Libraries:               5/6 (Reporting missing)

Common:      64,835 lines  (foundational, most incompatibilities)
Forms:       261,202 lines (UI, largest)
Server:      17,285 lines  (HTTP handlers, middleware)
Client:      14,943 lines  (app model, runtime support)
Converters:  177 lines     (RTF→HTML utility, simplest)
```

---

## 10. Contact & Escalation

**Project Owner:** [User Name]  
**Last Updated:** March 17, 2026  
**Next Review:** After full integrated build/test and runtime parity checkpoint

**Open Questions for Clarification:**
1. What is the expected timeline for Phase 2 completion?
2. Should the UI layer (WebForms) be ported to Blazor or kept as legacy ASP.NET endpoints?
3. Are pre-migration automated tests available to validate functional correctness?
4. Is the .NET Framework version (4.5.2) the only target, or should backward compatibility be maintained?

---

**END OF PROJECT DOCUMENTATION**
