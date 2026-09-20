# Student Requirements — Creational Patterns Lab

**Repo:** clone this repository and work on a branch named `solution/<your-name>`.

**Allowed patterns (use all three):**

1. Singleton with `Lazy<T>`
2. Prototype (deep clone)
3. Builder (fluent API)

Do **not** replace these with other patterns for this assignment.

---

## Problem 1 — Singleton (`Lazy<T>`)

**Location:** `src/PatternsLab/Problems/Singleton/`

**Current pain**

- `BillingFeature`, `ReportingFeature`, and `NotifyFeature` each call `new AppConfiguration()`.
- Construction is slow and each call gets a **different** `InstanceId`.
- Settings are supposed to be **one shared configuration** for the whole app.

**What you must do**

1. Refactor `AppConfiguration` into a **Singleton**.
2. Use **`Lazy<T>`** for thread-safe lazy initialization (not a hand-rolled double-check unless your instructor allows it *in addition* to Lazy).
3. Hide the constructor (private / non-public).
4. Expose a single accessor (e.g. `AppConfiguration.Instance`).
5. Update the three features to use that single instance.

**Acceptance**

- Running the runner prints **one** construction log.
- `AppConfiguration.ConstructedCount == 1`.
- All features print the **same** `InstanceId`.

---

## Problem 2 — Prototype

**Location:** `src/PatternsLab/Problems/Prototype/`

**Current pain**

- Building `ExamPaper.CreateMidtermBank()` is expensive.
- Teachers need a copy of the paper with small edits (title / duration).
- `CloneWrong()` shares nested `List`s — changing clone options changes the original (`HACKED` demo).

**What you must do**

1. Implement a proper **Prototype** deep clone (name it `Clone()`, or implement `ICloneable`, or a deep copy constructor — be consistent).
2. Nested `ExamQuestion` objects and their `Options` lists must be **independent** after cloning.
3. Update the runner demo to use your clone instead of `CloneWrong()`.
4. Keep `CreateMidtermBank()` as the expensive “create once” path; clones must not rebuild the bank from scratch.

**Acceptance**

- After changing `clone.Questions[0].Options[0]`, the **original** options stay unchanged.
- Clone keeps question count and can override `Title` / `DurationMinutes` independently.

---

## Problem 3 — Builder

**Location:** `src/PatternsLab/Problems/Builder/`

**Current pain**

- `CourseRegistration` uses a long constructor (telescoping / many optional args).
- Call sites in `RegistrationCallSites` are hard to read; bools can be swapped by mistake.
- Business rules:
  - `LiveGroup` **requires** `GroupCode`
  - `VideosOnly` **must not** have `GroupCode`

**What you must do**

1. Add a **Builder** (fluent methods like `WithEmail`, `AsLiveGroup`, `WithDiscount`, …).
2. `Build()` must validate the LiveGroup / VideosOnly rules (throw clear exceptions).
3. Rewrite `RegistrationCallSites` (or replace them) to use the builder — no long constructor lists at the call site.
4. Required fields (email, course code, access mode) must be obvious in the fluent flow.

**Acceptance**

- Live + VideosOnly examples are created via Builder and print correctly.
- Invalid combinations fail at `Build()` with a clear message.
- Call sites are readable without counting constructor parameter positions.

---

## Deliverables

1. Push your branch with the three refactors.
2. Short `NOTES.md` (max 1 page) listing for each problem:
   - what was wrong
   - what you changed
   - how you verified acceptance
3. `dotnet run --project src/PatternsLab.Runner` must succeed.

## Rules

- Keep the lab in **C# / .NET**.
- No deleting the problem demos — fix them.
- Do not add heavy frameworks; plain class library + console is enough.
