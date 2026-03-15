# Gizmox.WebGUI .NET 8 Migration Task Schedule

This document outlines a phased schedule of tasks to continue the migration project in a systematic, low‑risk manner. Phases are divided into short‑term, medium‑term, and long‑term workstreams. Dates are left open to allow flexibility, but each phase should be completed before moving on to the next.

---

## Phase 1 – Stabilize & Compile Core Libraries (March–April 2026)
*Estimated duration: 4–6 weeks*


1. **Split monolithic source files** *(1–2 weeks)*
   - Run and refine the Roslyn splitter on `Common.decompiled.cs` (already done).
   - Apply same process to `Forms`, `Client`, `Server`, `Converters`.
   - Move resulting files into namespace‑based folders and update `.csproj` `Compile` includes.
2. **Finalize `SystemWebShims`** *(2–3 weeks, concurrent with other tasks)*
   - Build `Common` repeatedly; add missing members/methods as errors surface.
   - Keep shim implementations minimal (throw until real logic is needed).
3. **Compile downstream projects** *(2–3 weeks overlap with split work)*
   - Build `Forms`; fix compilation errors by adjusting shims or patching code.
   - Cascade to `Client`, `Converters`, `Server` in dependency order.
4. **Resolve design‑time attributes and warnings** *(1 week)*
   - Remove/comment or suppress warnings for UITypeEditor, ToolboxBitmapAttribute, etc.
   - Add `<NoWarn>` entries if necessary.
5. **Locate or rebuild missing `Reporting` library** *(1–2 weeks depending on availability)*
   - Search repository/backups.
   - If found, decompile and add to solution; otherwise mark as deferred.
6. **Lightweight regression tests** *(ongoing throughout Phase 1)*
   - Create a small set of unit tests to assert key `Common` functionality.
   - Execute tests each time code changes to catch regressions.

*Outcome:* All 5 core libraries compile with zero errors and minimal warnings. The codebase is navigable and ready for further API work.

---

## Phase 2 – Address API Incompatibilities & Begin Refactoring (May–June 2026)
*Estimated duration: 6–8 weeks*


1. **Audit WebForms usage** *(1–2 weeks)*
   - Search for inheritance from `Control`, `Page`, `UserControl`.
   - Catalog lifecycle methods (`OnInit`, `OnLoad`, etc.) and `HtmlTextWriter` usage.
2. **Decide UI migration strategy** *(1 week)*
   - If WebForms is lightly used, continue with shims and leave actual UI migration to Phase 3.
   - If heavily used, start prototyping Blazor components or Razor pages for key screens.
3. **Enhance shims toward real implementations** *(2–3 weeks, iterative)*
   - For HTTP context types, wire shims to `Microsoft.AspNetCore.Http` via `IHttpContextAccessor`.
   - Replace `HttpRuntime.Cache` with `IMemoryCache` or `IDistributedCache` stubs.
   - Implement session stubs atop `ISession`.
4. **Refactor business logic away from static `HttpContext.Current`** *(2–4 weeks overlapping with shim work)*
   - Introduce abstractions to pass context objects explicitly.
   - Remove hidden dependencies on `HttpContext` where possible.
5. **Resolve remaining common library warnings** *(1–2 weeks as issues arise)*
   - Add nullable annotations or suppress warnings thoughtfully.
   - Remove obsolete `SecurityManager` calls or wrap them more cleanly.
6. **Add unit/integration tests for shim behavior** *(ongoing during Phase 2)*
   - Verify that shim classes throw or behave as expected.
   - Use ASP.NET Core test host to exercise HTTP-related code.

*Outcome:* Code compiles and behaves structurally correctly; API gaps are documented, and the groundwork for real ASP.NET Core integration is laid.

---

## Phase 3 – UI Port & End‑to‑End Validation (July–September 2026)
*Estimated duration: 12 weeks (3 months)*


1. **Select final UI framework** *(2 weeks to evaluate/prototype)*
   - Blazor Server, Blazor WebAssembly, or Razor Pages+MVC.
   - Start with a small pilot page to prove the chosen stack.
   - Pilot created in `NetCore/Gizmox.WebGUI.BlazorPilot` and now building on .NET 8.
2. **Incrementally port/replace WebForms controls** *(6–8 weeks ongoing)*
   - Build modern equivalents for frequently used controls.
   - Maintain feature parity and reuse existing logic where possible.
3. **Develop integration tests covering common user flows** *(4–6 weeks, overlapping UI work)*
   - Automate browser-based tests (Playwright/Selenium) against new UI.
   - Test session, caching, file upload/download, state management.
4. **Migrate server projects to full ASP.NET Core** *(4–6 weeks, iterative)*
   - Remove shims as real implementations arrive.
   - Configure `Program.cs`/`Startup.cs` for middleware, DI, static files.
5. **Ensure configuration compatibility** *(1–2 weeks)*
   - Translate old `web.config`/`app.config` settings to `appsettings.json` and options pattern.
6. **Performance profiling and tuning** *(lasting 2–4 weeks as areas mature)*
   - Run benchmarks comparing .NET Framework baseline vs. .NET 8.
   - Optimize hot paths, caching, serialization, and JSON handling.

*Outcome:* A functioning, modernized web application running on .NET 8 with a new UI. System.Web shims are obsolete.

---

## Phase 4 – Hardening & Prep for Production (October–November 2026)
*Estimated duration: 6–8 weeks*


1. **Complete test coverage** *(3–4 weeks)*
   - Achieve high code coverage for core libraries and critical UI paths.
   - Validate security (XSS, CSRF, authentication tokens).
2. **Deployment pipelines** *(2–3 weeks)*
   - Add CI/CD builds targeting .NET 8 (Azure DevOps, GitHub Actions, etc.).
   - Containerize applications (Docker) for cloud deployment.
3. **Documentation update** *(1–2 weeks)*
   - Write migration notes, API differences, and build/run instructions.
   - Archive old .NET Framework artifacts for reference.
4. **Plan post‑.NET 8 support** *(ongoing; initial plan 1–2 weeks)*
   - Track .NET 10 roadmap; establish timeline to upgrade again.
   - Evaluate any third‑party dependency lifecycles.

*Outcome:* Production‑ready .NET 8 platform with clear deployment workflow and documentation. Ready for go‑live before November 2026.

*Status:* In progress (March 2026): implemented GitHub Actions pipeline + Playwright browser install; Playwright e2e tests are skip-guarded for missing browser installation; coverage collector added.

---

## Ongoing & Optional Items

- **Expand migration process to other projects** using the documented checklist.
- **Open‑source the shim library** if permissible (helps community and reduces maintenance burden).
- **Refactor large classes** into smaller components once the code is split.
- **Monitor emerging .NET features** (Minimal APIs, source generators) for potential optimizations.

---

## Notes

- Prioritize correctness over speed; each phase is a milestone rather than a deadline.
- Use version control branches per phase or per major refactor to maintain a clean history.
- Keep legal documentation handy in case of questions about decompilation.

---

_Last updated: March 8, 2026_