using Framework.Pages.SauceDemo;
using NUnit.Framework;
using Reqnroll;
using Tests.Support;

namespace Tests.StepDefinitions;

[Binding]
public class SauceDemoSteps
{
    private readonly PwTestContext _tc;
    private LoginPage? _login;
    private InventoryPage? _inv;

    public SauceDemoSteps(PwTestContext tc) => _tc = tc;

    [Given("I open SauceDemo")]
    public async Task Open()
    {
        _login = new LoginPage(_tc.Page, _tc.Settings);
        await _login.OpenAsync();
    }

    [When(@"I login as ""(.*)"" with password ""(.*)""")]
    public async Task Login(string user, string pass)
        => await _login!.LoginAsync(user, pass);

    [Then("I should see inventory page")]
    public async Task AssertInventory()
    {
        _inv = new InventoryPage(_tc.Page, _tc.Settings);
        await _inv.WaitOpenedAsync();
        Assert.That(await _inv.GetTitleAsync(), Is.EqualTo("Products"));
    }
}