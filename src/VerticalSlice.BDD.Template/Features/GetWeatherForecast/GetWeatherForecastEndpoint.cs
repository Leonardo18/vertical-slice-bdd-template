using Wolverine;

namespace VerticalSlice.BDD.Template.Features.GetWeatherForecast
{
    internal static class GetWeatherForecastEndpoint
    {
        public static void MapGetWeatherForecast(this IEndpointRouteBuilder app)
        {
            _ = app.MapGet("/weatherforecast", async (IMessageBus bus) =>
            {
                IEnumerable<WeatherForecast> result = await bus.InvokeAsync<IEnumerable<WeatherForecast>>(new GetWeatherForecast());
                return Results.Ok(result);
            })
            .WithName("GetWeatherForecast");
        }
    }
}
