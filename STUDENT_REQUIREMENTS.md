# Student Requirements — Creational Patterns Lab

**Repo:** https://github.com/SimulationEG/csharp-creational-patterns-lab  

Clone the repo. Work on a branch: `solution/<your-name>`.

Run first:

```bash
dotnet run --project src/PatternsLab.Runner
```

Read the output. Fix each problem with the required pattern.

---

## 1) Singleton (`Lazy<T>`)

**Code:** `src/PatternsLab/Problems/Singleton/`

`DatabaseService` and `UiService` each create their own `AppConfig`. Changing the theme on one does not update the other. Loading from disk runs more than once.

| # | Requirement |
|---|-------------|
| R1 | Only one `AppConfig` object in the whole application. |
| R2 | Every class sees the same values. |
| R3 | The slow loading happens only once. |
| R4 | It is thread-safe. |
| R5 | Other code cannot create one with `new`. |

Use **`Lazy<T>`** for the Singleton.

**Done when:** theme change is visible to UI, `ReferenceEquals` is true, `LoadCount == 1`, constructor is not usable from outside.

---

## 2) Prototype

**Code:** `src/PatternsLab/Problems/Prototype/`

Creating many `Orc`s reloads the 3D model every time. `EnemyCopyHelper.CopyEnemy` is slow, type-switch based, cannot copy private `_modelData`, and shares `Weapon` / `Abilities` (shallow).

| # | Requirement |
|---|-------------|
| R1 | Creating a new enemy from an existing one must not repeat the slow loading. |
| R2 | Client code works with the base type `Enemy` and doesn't need to know if it is an `Orc` or `Elf`. |
| R3 | The copy must include private state (`_modelData`). |
| R4 | The copy must be independent: changing its `Weapon` or `Abilities` must not affect the original (deep copy). |
| R5 | (Bonus) A registry that stores named prototypes and returns clones on demand. |

**Done when:** cloning is fast, same `ModelId` as prototype, mutating copy does not change original, no `if (e is Orc)` in client copy logic.

---

## 3) Builder

**Code:** `src/PatternsLab/Problems/Builder/`

`CourseRegistration` uses a long constructor. Call sites are hard to read. Rules: `LiveGroup` needs `GroupCode`; `VideosOnly` must not have `GroupCode`.

| # | Requirement |
|---|-------------|
| R1 | Create registrations with a fluent **Builder** (no long argument lists at call sites). |
| R2 | Required vs optional steps are clear in the fluent API. |
| R3 | `Build()` validates LiveGroup / VideosOnly rules and throws clear errors. |
| R4 | Rewrite `RegistrationCallSites` to use the Builder. |

**Done when:** both sample registrations are built via Builder and invalid combinations fail at `Build()`.

---

## Deliverables

1. Branch with all three solutions.
2. Short `NOTES.md`: for each problem — what was wrong, what you changed, how you verified.
3. `dotnet run --project src/PatternsLab.Runner` succeeds.

## Rules

- C# / .NET only.
- Do not delete the demos — fix them.
- No heavy frameworks.
