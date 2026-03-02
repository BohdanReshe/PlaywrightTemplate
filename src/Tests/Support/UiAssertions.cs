using Microsoft.Playwright;
using NUnit.Framework;

namespace Tests.Support;

public static class UiAssertions
{
    public static async Task TextEqualsAsync(ILocator locator, string expected)
        => Assert.That(await locator.InnerTextAsync(), Is.EqualTo(expected));
}