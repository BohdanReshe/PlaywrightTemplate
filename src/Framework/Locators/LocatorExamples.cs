using Microsoft.Playwright;

namespace Framework.Locators;

public static class LocatorExamples
{
    public static ILocator ByRole(IPage page) =>
        page.GetByRole(AriaRole.Button, new() { Name = "Login" });

    public static ILocator ByCss(IPage page) =>
        page.Locator("#user-name");

    public static ILocator ByText(IPage page) =>
        page.GetByText("Dropdown");
}