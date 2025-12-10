using MediatR;
using WebApi.ViewModels;

namespace WebApi.Features.Weather.Query;

internal class GetWeatherQuery : IRequest<WeatherForecastViewModel[]>
{
}

internal class GetWeatherHandler : IRequestHandler<GetWeatherQuery, WeatherForecastViewModel[]>
{
    private readonly IRepository _repository;
    private readonly IExternalApi _externalApi;

    public GetWeatherHandler(IRepository repository, IExternalApi externalApi)
    {
        _repository = repository;
        _externalApi = externalApi;
    }

    internal static readonly string[] summaries = ["Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"];

    public async Task<WeatherForecastViewModel[]> Handle(GetWeatherQuery request, CancellationToken cancellationToken)
    {
        var forecast = Enumerable.Range(1, 5)
                .Select(index =>
                new WeatherForecastViewModel
                (
                    DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    Random.Shared.Next(-20, 55),
                    summaries[Random.Shared.Next(summaries.Length)]
                ))
                .ToArray();
        _ = Task.Run(RunInBackgroundTaskAsync, cancellationToken);
        return forecast;
        // Quest 1: Are _repository and _externalApi disposed here?
        // Dispose will be call after the respose return to user, and request pipeline ends. _repository and _externalApi call Dispose methods, they themselves are not disposed. GC will collect them if no any active references.
    }

    private async Task RunInBackgroundTaskAsync()
    {
        try
        {
            // Question 2: Does ObjectDisposedException throws here?
            await _repository.GetDataAsync();
            await _externalApi.GetExternalDataAsync();
            await _repository.SaveDataAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
    }
}
