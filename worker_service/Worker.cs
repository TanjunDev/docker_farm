namespace worker_service;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;

    public Worker(ILogger<Worker> logger)
    {
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            WriteTextFile();
            await Task.Delay(5000, stoppingToken);
        }
    }

    public static void WriteTextFile()
    {
        // Write to a file on current directory
        string path = "log.txt";

        using StreamWriter sw = File.AppendText(path);
        sw.WriteLine("Worker running at: {0}", DateTimeOffset.Now);
    }
}
