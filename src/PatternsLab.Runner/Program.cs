using PatternsLab.Problems.Builder;
using PatternsLab.Problems.Prototype;
using PatternsLab.Problems.Singleton;

Console.WriteLine("=== PROBLEM 1: Singleton (Lazy) — watch multiple constructions ===");
BillingFeature.Run();
ReportingFeature.Run();
NotifyFeature.Run();
Console.WriteLine($"ConstructedCount={AppConfiguration.ConstructedCount} (should become 1 after Lazy Singleton)\n");

Console.WriteLine("=== PROBLEM 2: Prototype — broken shallow clone ===");
var original = ExamPaper.CreateMidtermBank();
var clone = original.CloneWrong();
clone.Title = "OOP Midterm — Make-up";
clone.DurationMinutes = 60;
clone.Questions[0].Options[0] = "HACKED"; // corrupts original too
original.PrintSummary("original");
clone.PrintSummary("clone   ");
Console.WriteLine("If original q1.options shows HACKED — clone is wrong. Fix with deep Prototype.\n");

Console.WriteLine("=== PROBLEM 3: Builder — telescoping constructor call sites ===");
Console.WriteLine(RegistrationCallSites.CreateLiveStudentUgly());
Console.WriteLine(RegistrationCallSites.CreateVideosOnlyUgly());
Console.WriteLine("Replace call sites with a fluent Builder + validation.");
