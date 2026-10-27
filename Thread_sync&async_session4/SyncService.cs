namespace Thread_sync_async_session4;

public class ASyncDataService
{
    public async Task<string> FetchDataFromDatabaseASync()
    {
        Console.WriteLine($"[{Environment.CurrentManagedThreadId}]");
        await Task.Delay(2000);
        return "Database result";
    }

    public async Task<string> FetchDataFromApiASync()
    {
        Console.WriteLine($"[{Environment.CurrentManagedThreadId}]");
        await Task.Delay(1500);
        return "API result";
    }

    public async Task DoSomething()
    {
        await Task.Delay(100);
    }
}

