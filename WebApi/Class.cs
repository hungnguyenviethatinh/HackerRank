
namespace WebApi;

public interface IRepository
{
    Task GetDataAsync();
    Task SaveDataAsync();
}

public class Repository : IRepository, IDisposable
{
    public void Dispose()
    {
        Console.WriteLine("Repository disposed");
    }

    public async Task GetDataAsync()
    {
        // Simulate getting data from database.
        await Task.Delay(TimeSpan.FromSeconds(3));
    }
    public async Task SaveDataAsync()
    {
        // Simulate saving data to database.
        await Task.Delay(TimeSpan.FromSeconds(3));
    }
}

public interface IExternalApi
{
    Task GetExternalDataAsync();
}

public class ExternalApi : IExternalApi, IDisposable
{
    private readonly IRepository _repository;
    private readonly HttpClient _httpClient;
    public ExternalApi(IRepository repository, HttpClient httpClient)
    {
        _repository = repository;
        _httpClient = httpClient;
    }

    public void Dispose()
    {
        Console.WriteLine("IExternalApi disposed");
        //_httpClient.Dispose(); // Dispose HttpClient will help throw ObjectDisposedException
    }

    public async Task GetExternalDataAsync()
    {
        // Simulate getting data from external api with HttpClient
        //await _httpClient.GetAsync("");
        await Task.Delay(TimeSpan.FromSeconds(3));
        await _repository.SaveDataAsync();
    }
}

public class DisposableClass : IDisposable
{
    public void Dispose()
    {
        Console.WriteLine("Disposed");
    }
}

public class BackgroundJob : BackgroundService
{
    private readonly IServiceScopeFactory _serviceScopeFactory;
    public BackgroundJob(IServiceScopeFactory serviceScopeFactory)
    {
        _serviceScopeFactory = serviceScopeFactory;
    }
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        using (var disposableClass = new DisposableClass())
        {
            Console.WriteLine("In scope of disposableClass");
        }
        // Will call Dispose here.

        await using (var scope = _serviceScopeFactory.CreateAsyncScope())
        {
            var repository = scope.ServiceProvider.GetRequiredService<IRepository>();
            //var externalApi = scope.ServiceProvider.GetRequiredService<IExternalApi>();
            await repository.GetDataAsync();
            _ = Task.Run(async () =>
            {
                try
                {
                    await repository.SaveDataAsync(); // Question 1: Why this line not throw ObjectDisposedException? Answer: repository is already resolved, so its reference exists
                   var externalApi = scope.ServiceProvider.GetRequiredService<IExternalApi>(); // Question 2: Why this line throw ObjectDisposedException? Answer: Because scope already called Dispose to disposed ServiceProver.
                    await externalApi.GetExternalDataAsync();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }, stoppingToken);
        }
        // End of scope, scope will be disposed here
        // Question 3: Is the variable repository disposed too?
        // Answer: No, it just call Dispose method, it itself is not disposed. So its instance still exists in Task.Run.
        // for var scope, it will call scope Dispose to dispose ServiceProvider
    }
}
