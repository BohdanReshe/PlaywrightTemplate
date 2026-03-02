using Framework.Config;
using Microsoft.Playwright;

namespace Tests.Support;

public class PwTestContext
{
    public TestSettings Settings { get; }
    public IPlaywright Playwright { get; }
    public IBrowser Browser { get; }
    public IBrowserContext Context { get; }
    public IPage Page { get; }

    public PwTestContext(TestSettings settings, IPlaywright pw, IBrowser browser, IBrowserContext ctx, IPage page)
    {
        Settings = settings;
        Playwright = pw;
        Browser = browser;
        Context = ctx;
        Page = page;
    }
}