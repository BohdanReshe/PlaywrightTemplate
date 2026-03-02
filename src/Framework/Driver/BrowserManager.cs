using Framework.Config;
using Microsoft.Playwright;

namespace Framework.Driver;

public static class BrowserManager
{
    public static async Task<IBrowser> LaunchAsync(IPlaywright pw, TestSettings settings)
    {
        var opts = new BrowserTypeLaunchOptions
        {
            Headless = settings.Headless,
            SlowMo = settings.SlowMoMs
        };

        return settings.Browser.ToLowerInvariant() switch
        {
            "firefox" => await pw.Firefox.LaunchAsync(opts),
            "webkit" => await pw.Webkit.LaunchAsync(opts),
            _ => await pw.Chromium.LaunchAsync(opts)
        };
    }
}