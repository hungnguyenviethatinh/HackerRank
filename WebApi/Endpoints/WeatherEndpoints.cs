using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApi.Features.Weather.Query;
using WebApi.ViewModels;

namespace WebApi.Endpoints;

internal static class WeatherEndpoints
{
    public static WebApplication RegisterWeatherEndpoints(this WebApplication app)
    {
        app.MapGet("/weatherforecast", async ([FromServices] IMediator mediator) =>
        {
            GetWeatherQuery query = new();
            WeatherForecastViewModel[] forecast = await mediator.Send(query);

            return TypedResults.Ok(forecast);
        })
        .WithName("GetWeatherForecast")
        .WithOpenApi();

        return app;
    }
}
