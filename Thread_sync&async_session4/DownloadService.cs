namespace Thread_sync_async_session4;

public class DownloadService
{
    public async Task<string> DownloadFileAsync(string fileName,
        CancellationToken cancellationToken = default)
    {
        Console.WriteLine($"Starting download {fileName}");
        for (int i = 0; i <= 100; i++)
        {
            cancellationToken.ThrowIfCancellationRequested();

            Console.WriteLine($"Downloading {fileName} {i}%");

            await Task.Delay(500, cancellationToken);
        }
        return $"File {fileName} download successfully.";
    }

    public async Task<string> DownloadWithTimeOut(string fileName,
        int timeOutMs)
    {
        using CancellationTokenSource cts = new CancellationTokenSource();
        cts.CancelAfter(timeOutMs);
        try
        {
            await DownloadFileAsync(fileName, cts.Token);
        }
        catch (OperationCanceledException ex)
        {

        }

        return $"File {fileName} download successfully.";
    }


}
