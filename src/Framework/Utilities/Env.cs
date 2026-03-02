namespace Framework.Utilities;

public static class Env
{
    public static string Get(string name, string fallback = "")
        => Environment.GetEnvironmentVariable(name) ?? fallback;

    public static bool GetBool(string name, bool fallback)
        => bool.TryParse(Get(name), out var v) ? v : fallback;

    public static int GetInt(string name, int fallback)
        => int.TryParse(Get(name), out var v) ? v : fallback;
}