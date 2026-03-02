using Framework.Config;
using Framework.Driver;
using Microsoft.Playwright;
using Reqnroll;

namespace Tests.Hooks;

[Binding]
public sealed class TestRunHooks
{
    private static IPlaywright? _pw;
    private static IBrowser? _browser;
    private static TestSettings? _settings;

    [BeforeTestRun]
    public static async Task BeforeTestRun()
    {
        _settings = SettingsLoader.Load();
        _pw = await PlaywrightFactory.CreateAsync();
        _browser = await BrowserManager.LaunchAsync(_pw, _settings);
    }

    [AfterTestRun]
    public static async Task AfterTestRun()
    {
        if (_browser is not null) await _browser.CloseAsync();
        _pw?.Dispose();
    }

    public static (IPlaywright pw, IBrowser browser, TestSettings settings) Shared()
        => (_pw!, _browser!, _settings!);
}