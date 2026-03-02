using Framework.Config;
using Microsoft.Playwright;
using Framework.Pages;

namespace Framework.Pages.Herokuapp;

public class HomePage : BasePage
{
    public HomePage(IPage page, TestSettings settings) : base(page, settings) { }

    public ILocator DropdownLink => Page.GetByRole(AriaRole.Link, new() { Name = "Dropdown" });

    public Task OpenAsync() => ActAsync(() => Page.GotoAsync(Settings.BaseUrlHeroku));
    public Task GoToDropdownAsync() => ActAsync(() => DropdownLink.ClickAsync());
}