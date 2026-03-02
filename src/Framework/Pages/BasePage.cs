using Framework.Config;
using Framework.Utilities;
using Microsoft.Playwright;

namespace Framework.Pages;

public abstract class BasePage
{
    protected readonly IPage Page;
    protected readonly TestSettings Settings;

    protected BasePage(IPage page, TestSettings settings)
    {
        Page = page;
        Settings = settings;
    }

    protected Task ActAsync(Func<Task> action)
        => Retry.RunAsync(action, Settings.Retries);

    protected Task<T> ActAsync<T>(Func<Task<T>> action)
        => Retry.RunAsync(action, Settings.Retries);
}