using Framework.Config;
using Microsoft.Playwright;
using Framework.Pages;

namespace Framework.Pages.Herokuapp;

public class DropdownPage : BasePage
{
    public DropdownPage(IPage page, TestSettings settings) : base(page, settings) { }

    private ILocator Dropdown => Page.Locator("#dropdown");

    public Task SelectAsync(string value) => ActAsync(() =>
        Dropdown.SelectOptionAsync(new SelectOptionValue { Value = value }));

    public Task<string> SelectedAsync() => ActAsync(() => Dropdown.InputValueAsync());
}