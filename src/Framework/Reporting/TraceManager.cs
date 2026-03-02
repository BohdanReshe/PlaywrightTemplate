using Microsoft.Playwright;

namespace Framework.Reporting;

public static class TraceManager
{
    public static Task StartAsync(IBrowserContext context)
        => context.Tracing.StartAsync(new()
        {
            Screenshots = true,
            Snapshots = true,
            Sources = true
        });

    public static Task StopAsync(IBrowserContext context, string tracePath)
        => context.Tracing.StopAsync(new() { Path = tracePath });
}