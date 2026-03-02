using Microsoft.Playwright;

namespace Framework.Pages.Components;

public class HeaderComponent
{
    private readonly IPage _page;
    public HeaderComponent(IPage page) => _page = page;

    public ILocator MenuButton => _page.GetByRole(AriaRole.Button, new() { Name = "Open Menu" });
}