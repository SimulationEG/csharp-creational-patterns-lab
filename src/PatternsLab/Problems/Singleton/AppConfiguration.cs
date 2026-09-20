namespace PatternsLab.Problems.Singleton;

/// <summary>
/// PROBLEM 1 — Singleton (Lazy&lt;T&gt;)
///
/// Pain: every feature does <c>new AppConfiguration()</c>.
/// Loading pretend settings is slow and you get MANY independent instances
/// (different Ids), so "global settings" are not global at all.
///
/// YOUR TASK: make <see cref="AppConfiguration"/> a Lazy Singleton so the whole
/// process shares exactly one instance. Prefer <c>Lazy&lt;T&gt;</c> (thread-safe).
/// Do not use a public constructor from outside after the refactor.
/// </summary>
public sealed class AppConfiguration
{
    private static int _constructed;

    /// <summary>Unique per construction — proves multiple instances today.</summary>
    public Guid InstanceId { get; }

    public string ConnectionString { get; }
    public string EnvironmentName { get; }
    public int MaxRetryCount { get; }

    public AppConfiguration()
    {
        // Pretend: read appsettings / remote config (expensive).
        Thread.Sleep(80);
        _constructed++;
        InstanceId = Guid.NewGuid();
        ConnectionString = "Server=localhost;Database=Academy;";
        EnvironmentName = "Development";
        MaxRetryCount = 3;
        Console.WriteLine($"[AppConfiguration] constructed #{_constructed} id={InstanceId:N}");
    }

    public static int ConstructedCount => _constructed;
}

/// <summary>Feature A — currently creates its own config instance.</summary>
public static class BillingFeature
{
    public static void Run()
    {
        var config = new AppConfiguration();
        Console.WriteLine($"Billing uses config {config.InstanceId:N} retries={config.MaxRetryCount}");
    }
}

/// <summary>Feature B — another independent <c>new AppConfiguration()</c>.</summary>
public static class ReportingFeature
{
    public static void Run()
    {
        var config = new AppConfiguration();
        Console.WriteLine($"Reporting uses config {config.InstanceId:N} env={config.EnvironmentName}");
    }
}

/// <summary>Feature C — third copy. After Singleton, all three must share one InstanceId.</summary>
public static class NotifyFeature
{
    public static void Run()
    {
        var config = new AppConfiguration();
        Console.WriteLine($"Notify uses config {config.InstanceId:N} cs={config.ConnectionString}");
    }
}
