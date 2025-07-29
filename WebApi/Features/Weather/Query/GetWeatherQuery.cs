using MediatR;
using WebApi.ViewModels;

namespace WebApi.Features.Weather.Query;

internal class GetWeatherQuery : IRequest<WeatherForecastViewModel[]>
{
}

internal class GetWeatherHandler : IRequestHandler<GetWeatherQuery, WeatherForecastViewModel[]>
{
    internal static readonly string[] summaries = ["Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"];

    public async Task<WeatherForecastViewModel[]> Handle(GetWeatherQuery request, CancellationToken cancellationToken)
    {
        return await Task.Run(() =>
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

            return forecast;
        });
    }
}
