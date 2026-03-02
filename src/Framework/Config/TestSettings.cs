namespace Framework.Config;

public record TestSettings(
    string Env,
    string Browser,
    bool Headless,
    int SlowMoMs,
    string BaseUrlSauce,
    string BaseUrlHeroku,
    string TraceMode,
    string VideoMode,
    string ScreenshotMode,
    int Retries,
    int TestTimeoutMs,
    string PrRef
);