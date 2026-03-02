using Framework.Pages.Herokuapp;
using NUnit.Framework;
using Reqnroll;
using Tests.Support;

namespace Tests.StepDefinitions;

[Binding]
public class HerokuappSteps
{
    private readonly PwTestContext _tc;
    private HomePage? _home;
    private DropdownPage? _dd;

    public HerokuappSteps(PwTestContext tc) => _tc = tc;

    [Given("I open Herokuapp")]
    public async Task Open()
    {
        _home = new HomePage(_tc.Page, _tc.Settings);
        await _home.OpenAsync();
    }

    [When("I go to Dropdown page")]
    public async Task Go()
    {
        await _home!.GoToDropdownAsync();
        _dd = new DropdownPage(_tc.Page, _tc.Settings);
    }

    [When(@"I select option ""(.*)""")]
    public async Task Select(string v) => await _dd!.SelectAsync(v);

    [Then(@"selected option should be ""(.*)""")]
    public async Task AssertSelected(string v)
        => Assert.That(await _dd!.SelectedAsync(), Is.EqualTo(v));
}