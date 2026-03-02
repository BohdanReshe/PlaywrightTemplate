using Microsoft.Playwright;

namespace Framework.Utilities;

public static class Waits
{
    public static async Task UntilVisibleAsync(ILocator locator, int timeoutMs)
        => await locator.WaitForAsync(new() { State = WaitForSelectorState.Visible, Timeout = timeoutMs });
}