using Microsoft.Playwright;

namespace Framework.Driver;

public static class PlaywrightFactory
{
    public static Task<IPlaywright> CreateAsync() => Playwright.CreateAsync();
}