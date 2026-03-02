using Framework.Config;
using Microsoft.Playwright;

namespace Framework.Driver;

public static class ContextManager
{
    public static async Task<IBrowserContext> NewContextAsync(IBrowser browser, TestSettings settings)
    {
        var ctx = await browser.NewContextAsync(new()
        {
            ViewportSize = new() { Width = 1280, Height = 800 }
        });

        ctx.SetDefaultTimeout(settings.TestTimeoutMs);
        ctx.SetDefaultNavigationTimeout(settings.TestTimeoutMs);

        return ctx;
    }
}