using Framework.Utilities;

namespace Framework.Config;

public static class SettingsLoader
{
    public static TestSettings Load()
    {
        var prRef = Env.Get("PR_REF", "");

        string NormalizeBaseUrl(string url)
        {
            if (!url.Contains("#{}#", StringComparison.Ordinal))
                return url;

            var replaced = url.Replace("#{}#", prRef, StringComparison.Ordinal);
            return replaced.Replace("#", "", StringComparison.Ordinal);
        }

        return new TestSettings(
            Env: Env.Get("ENV", "local"),
            Browser: Env.Get("BROWSER", "chromium"),
            Headless: Env.GetBool("HEADLESS", true),
            SlowMoMs: Env.GetInt("SLOWMO_MS", 0),
            BaseUrlSauce: NormalizeBaseUrl(Env.Get("BASEURL_SAUCE", "https://www.saucedemo.com")),
            BaseUrlHeroku: NormalizeBaseUrl(Env.Get("BASEURL_HEROKU", "https://the-internet.herokuapp.com")),
            TraceMode: Env.Get("TRACE_MODE", "on-failure"),
            VideoMode: Env.Get("VIDEO_MODE", "off"),
            ScreenshotMode: Env.Get("SCREENSHOT_MODE", "only-on-failure"),
            Retries: Env.GetInt("RETRIES", 2),
            TestTimeoutMs: Env.GetInt("TEST_TIMEOUT_MS", 30000),
            PrRef: prRef
        );
    }
}