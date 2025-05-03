using Wolverine;

namespace VerticalSlice.BDD.Template.Features.CreateWeatherForecast
{
    internal static class CreateWeatherForecastEndpoint
    {
        public static void MapCreateWeatherForecast(this IEndpointRouteBuilder app)
        {
            _ = app.MapPost("/weatherforecast", async (CreateWeatherForecast command, IMessageBus bus) =>
            {
                IResult result = await bus.InvokeAsync<IResult>(command).ConfigureAwait(false);
                return result;
            })
            .WithName("CreateWeatherForecast");
        }
    }
}
