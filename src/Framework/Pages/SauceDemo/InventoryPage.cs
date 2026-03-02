using Framework.Config;
using Microsoft.Playwright;
using Framework.Pages;

namespace Framework.Pages.SauceDemo;

public class InventoryPage : BasePage
{
    public InventoryPage(IPage page, TestSettings settings) : base(page, settings) { }

    private ILocator Title => Page.Locator(".title"); // semantic css

    public Task WaitOpenedAsync() => ActAsync(() => Page.WaitForURLAsync("**/inventory.html"));

    public Task<string> GetTitleAsync() => ActAsync(() => Title.InnerTextAsync());
}