namespace WebApi;

public class Job : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        const int MAX_TRY = 3;
        int[] timePerRetry = [1, 2, 3];
        int retryCount = 0;

        while (!stoppingToken.IsCancellationRequested)
        {
            DateTime now = DateTime.Now;
            DateTime nextRun = new(now.Year, now.Month, now.Day, 20, 0, 0);

            try
            {
                if (now > nextRun)
                {
                    if (retryCount < MAX_TRY)
                    {
                        RunJob();
                    }

                    retryCount = 0;
                    nextRun = nextRun.AddDays(1);
                }

                TimeSpan delay = nextRun - now;
                await Task.Delay(delay, stoppingToken);
            }
            catch (OperationCanceledException) when (stoppingToken.IsCancellationRequested)
            {
                break;
            }
            catch (JobException)
            {
                TimeSpan retryDelay = TimeSpan.FromMinutes(timePerRetry[retryCount]);
                retryCount++;
                await Task.Delay(retryDelay, stoppingToken);
            }
            catch (Exception)
            {

            }
        }
    }

    public void RunJob()
    {
        try
        {
            //throw new Exception("test failed job.");
        }
        catch (Exception e)
        {
            throw new JobException("test", e);
        }
    }

    class JobException : Exception
    {
        public JobException() : base()
        {

        }

        public JobException(string? message) : base(message)
        {

        }

        public JobException(string? message, Exception innerException) : base(message, innerException) { }
    }
}
