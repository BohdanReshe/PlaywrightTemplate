namespace Framework.Utilities;

public static class Retry
{
    public static async Task RunAsync(Func<Task> action, int retries, int delayMs = 200)
    {
        Exception? last = null;

        for (var attempt = 0; attempt <= retries; attempt++)
        {
            try
            {
                await action();
                return;
            }
            catch (Exception ex)
            {
                last = ex;
                if (attempt == retries) break;
                await Task.Delay(delayMs);
            }
        }

        throw last!;
    }

    public static async Task<T> RunAsync<T>(Func<Task<T>> action, int retries, int delayMs = 200)
    {
        Exception? last = null;

        for (var attempt = 0; attempt <= retries; attempt++)
        {
            try
            {
                return await action();
            }
            catch (Exception ex)
            {
                last = ex;
                if (attempt == retries) break;
                await Task.Delay(delayMs);
            }
        }

        throw last!;
    }
}