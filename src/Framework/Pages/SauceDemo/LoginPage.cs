using Framework.Config;
using Microsoft.Playwright;
using Framework.Pages;

namespace Framework.Pages.SauceDemo;

public class LoginPage : BasePage
{
    public LoginPage(IPage page, TestSettings settings) : base(page, settings) { }

    // CSS by id
    private ILocator UserName => Page.Locator("#user-name");
    private ILocator Password => Page.Locator("#password");

    // Role-based (accessibility)
    private ILocator LoginButton => Page.GetByRole(AriaRole.Button, new() { Name = "Login" });

    // data-test
    public ILocator Error => Page.Locator("[data-test='error']");

    public Task OpenAsync() => ActAsync(() => Page.GotoAsync(Settings.BaseUrlSauce));

    public Task LoginAsync(string user, string pass) => ActAsync(async () =>
    {
        await UserName.FillAsync(user);
        await Password.FillAsync(pass);
        await LoginButton.ClickAsync();
    });
}