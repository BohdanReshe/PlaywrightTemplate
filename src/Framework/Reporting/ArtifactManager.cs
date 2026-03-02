using Microsoft.Playwright;

namespace Framework.Reporting;

public static class ArtifactManager
{
    public static string ArtifactsRoot(string workDir) =>
        Path.Combine(workDir, "artifacts");

    public static string NewFolderFor(string workDir, string scenarioName)
    {
        var safe = string.Join("_", scenarioName.Split(Path.GetInvalidFileNameChars()));
        var path = Path.Combine(ArtifactsRoot(workDir), $"{DateTime.UtcNow:yyyyMMdd_HHmmss}_{safe}");
        Directory.CreateDirectory(path);
        return path;
    }

    public static async Task<string> ScreenshotAsync(IPage page, string folder, string name = "failure.png")
    {
        var path = Path.Combine(folder, name);
        await page.ScreenshotAsync(new() { Path = path, FullPage = true });
        return path;
    }
}