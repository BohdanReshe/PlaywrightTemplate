using Framework.Driver;
using Framework.Reporting;
using Reqnroll;
using Tests.Support;
using Reqnroll.BoDi;
using NUnitTestContext = NUnit.Framework.TestContext;

namespace Tests.Hooks;

[Binding]
public sealed class ScenarioHooks
{
    private readonly ScenarioContext _scenario;
    private readonly IObjectContainer _container;
    private string? _artifactFolder;

    public ScenarioHooks(ScenarioContext scenario, IObjectContainer container)
    {
        _scenario = scenario;
        _container = container;
    }

    [BeforeScenario]
    public async Task BeforeScenario()
    {
        var (pw, browser, settings) = TestRunHooks.Shared();

        var ctx = await ContextManager.NewContextAsync(browser, settings);
        var page = await ctx.NewPageAsync();

        await TraceManager.StartAsync(ctx);

        _container.RegisterInstanceAs(new PwTestContext(settings, pw, browser, ctx, page));
    }

    [AfterScenario]
    public async Task AfterScenario()
    {
        var tc = _container.Resolve<PwTestContext>();

        var failed = _scenario.TestError is not null;

        if (failed)
        {
            _artifactFolder ??= Framework.Reporting.ArtifactManager.NewFolderFor(
                NUnitTestContext.CurrentContext.WorkDirectory,
                _scenario.ScenarioInfo.Title);

            var screenshotPath = await Framework.Reporting.ArtifactManager.ScreenshotAsync(tc.Page, _artifactFolder);
            NUnitTestContext.AddTestAttachment(screenshotPath, "Screenshot");

            var tracePath = Path.Combine(_artifactFolder, "trace.zip");
            await Framework.Reporting.TraceManager.StopAsync(tc.Context, tracePath);
            NUnitTestContext.AddTestAttachment(tracePath, "Trace");
        }
        else
        {
            await tc.Context.Tracing.StopAsync();
        }

        await tc.Context.CloseAsync();
    }
}