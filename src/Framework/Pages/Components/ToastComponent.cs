using Microsoft.Playwright;

namespace Framework.Pages.Components;

public class ToastComponent
{
    private readonly IPage _page;
    public ToastComponent(IPage page) => _page = page;

    public ILocator Container => _page.Locator("[role='alert']");
}