namespace PatternsLab.Problems.Builder;

/// <summary>
/// PROBLEM 3 — Builder
///
/// Pain: <see cref="CourseRegistration"/> has many optional fields.
/// Call sites use telescoping constructors + remember argument order,
/// or set public fields after <c>new</c> and forget required combinations
/// (LiveGroup requires GroupCode; VideosOnly must not set GroupCode).
///
/// YOUR TASK: introduce a Builder (fluent) that:
/// - makes required vs optional clear
/// - validates incompatible combinations before Build()
/// - removes the need for long constructor argument lists at call sites
/// Keep the final product as an immutable-ish registration object if you can.
/// </summary>
public sealed class CourseRegistration
{
    public string StudentEmail { get; }
    public string CourseCode { get; }
    public string AccessMode { get; }          // "LiveGroup" | "VideosOnly"
    public string? GroupCode { get; }
    public string? DiscountCode { get; }
    public bool SendWhatsApp { get; }
    public bool SendEmailWelcome { get; }
    public string? MentorNote { get; }
    public DateOnly? PreferredStart { get; }

    // Telescoping mess — hard to call, easy to swap args.
    public CourseRegistration(
        string studentEmail,
        string courseCode,
        string accessMode,
        string? groupCode,
        string? discountCode,
        bool sendWhatsApp,
        bool sendEmailWelcome,
        string? mentorNote,
        DateOnly? preferredStart)
    {
        if (string.IsNullOrWhiteSpace(studentEmail)) throw new ArgumentException("email required");
        if (string.IsNullOrWhiteSpace(courseCode)) throw new ArgumentException("course required");

        if (accessMode == "LiveGroup" && string.IsNullOrWhiteSpace(groupCode))
            throw new InvalidOperationException("LiveGroup requires GroupCode");
        if (accessMode == "VideosOnly" && !string.IsNullOrWhiteSpace(groupCode))
            throw new InvalidOperationException("VideosOnly cannot have GroupCode");

        StudentEmail = studentEmail;
        CourseCode = courseCode;
        AccessMode = accessMode;
        GroupCode = groupCode;
        DiscountCode = discountCode;
        SendWhatsApp = sendWhatsApp;
        SendEmailWelcome = sendEmailWelcome;
        MentorNote = mentorNote;
        PreferredStart = preferredStart;
    }

    public override string ToString()
        => $"{StudentEmail} → {CourseCode} [{AccessMode}] group={GroupCode ?? "-"} discount={DiscountCode ?? "-"} wa={SendWhatsApp} mail={SendEmailWelcome}";
}

/// <summary>
/// Call-site pain demo — after Builder, this should become readable fluent calls.
/// </summary>
public static class RegistrationCallSites
{
    public static CourseRegistration CreateLiveStudentUgly()
    {
        // Which bool is WhatsApp? Which is email? Easy to swap.
        return new CourseRegistration(
            "sara@mail.com",
            "SEF-101",
            "LiveGroup",
            "G1",
            "EARLY10",
            true,
            true,
            "Needs evening slot",
            new DateOnly(2026, 10, 1));
    }

    public static CourseRegistration CreateVideosOnlyUgly()
    {
        return new CourseRegistration(
            "ali@mail.com",
            "SEF-101",
            "VideosOnly",
            null,
            null,
            false,
            true,
            null,
            null);
    }
}
