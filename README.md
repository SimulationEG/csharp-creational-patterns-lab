# PatternsLab — Creational Patterns (C#)

Simulation diploma lab. Three **clear** problems. Apply exactly:

| # | Pattern | Folder |
|---|---------|--------|
| 1 | **Singleton** using `Lazy<T>` | `Problems/Singleton` |
| 2 | **Prototype** (deep clone) | `Problems/Prototype` |
| 3 | **Builder** (fluent) | `Problems/Builder` |

## Run (before you refactor)

```bash
dotnet run --project src/PatternsLab.Runner
```

You should observe:

1. `AppConfiguration` constructed **3 times** (different `InstanceId`s)
2. Cloning an `ExamPaper` **corrupts** the original options (`HACKED`)
3. `CourseRegistration` created with an unreadable constructor argument list

## Docs for students

See **[STUDENT_REQUIREMENTS.md](STUDENT_REQUIREMENTS.md)** — send that file to the class.
