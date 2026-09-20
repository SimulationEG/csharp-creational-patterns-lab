namespace PatternsLab.Problems.Prototype;

/// <summary>
/// PROBLEM 2 — Prototype
///
/// Pain: building a full exam paper is expensive (many questions + nested options).
/// Teachers need "same paper, small tweaks" (title / duration) without rebuilding
/// every question from scratch.
///
/// Today <see cref="ExamPaper.CloneWrong"/> is a shallow / broken copy:
/// changing options on the clone corrupts the original (shared lists).
///
/// YOUR TASK: implement a proper Prototype (deep clone) so:
/// - clone is independent (mutating clone does not change original)
/// - clone is faster / simpler than rebuilding questions manually
/// Prefer a <c>Clone()</c> / <c>ICloneable</c> / copy-constructor deep clone —
/// pick one style and use it consistently.
/// </summary>
public sealed class ExamPaper
{
    public string Title { get; set; }
    public int DurationMinutes { get; set; }
    public List<ExamQuestion> Questions { get; set; } = new();

    public ExamPaper(string title, int durationMinutes)
    {
        Title = title;
        DurationMinutes = durationMinutes;
    }

    /// <summary>Simulates expensive authoring of a full bank of questions.</summary>
    public static ExamPaper CreateMidtermBank()
    {
        Console.WriteLine("[ExamPaper] building full question bank (expensive)...");
        Thread.Sleep(120);

        var paper = new ExamPaper("OOP Midterm", 90);
        for (var i = 1; i <= 8; i++)
        {
            paper.Questions.Add(new ExamQuestion
            {
                Prompt = $"Q{i}: Explain concept #{i}",
                Points = 5,
                Options = new List<string> { "A", "B", "C", "D" }
            });
        }

        return paper;
    }

    /// <summary>
    /// BROKEN clone — shared nested lists. Students must replace this with a deep Prototype.
    /// </summary>
    public ExamPaper CloneWrong()
    {
        return new ExamPaper(Title, DurationMinutes)
        {
            Questions = Questions // BUG: same list instances inside
        };
    }

    public void PrintSummary(string label)
    {
        var firstOptions = Questions.Count == 0 ? "-" : string.Join("/", Questions[0].Options);
        Console.WriteLine($"{label}: '{Title}' {DurationMinutes}m questions={Questions.Count} q1.options={firstOptions}");
    }
}

public sealed class ExamQuestion
{
    public string Prompt { get; set; } = "";
    public int Points { get; set; }
    public List<string> Options { get; set; } = new();
}
