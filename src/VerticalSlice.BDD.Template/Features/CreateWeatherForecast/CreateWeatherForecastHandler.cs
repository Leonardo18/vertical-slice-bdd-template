namespace VerticalSlice.BDD.Template.Features.CreateWeatherForecast
{
    public class CreateWeatherForecastHandler
    {
        public Task<IResult> Handle(CreateWeatherForecast command)
        {
            var errors = Validate(command);
            if (errors.Any())
                return Task.FromResult(Results.BadRequest(new { errors }));

            var response = new
            {
                Id = Guid.NewGuid(),
                command.Date,
                command.TemperatureC,
                command.Summary
            };

            return Task.FromResult(Results.Created($"/weatherforecast/{response.Id}", response));
        }

        private static IEnumerable<string> Validate(CreateWeatherForecast command)
        {
            var errors = new List<string>();

            if (command.TemperatureC is < -50 or > 60)
                errors.Add("TemperatureC must be between -50 and 60.");

            if (command.Date < DateOnly.FromDateTime(DateTime.Today))
                errors.Add("Date cannot be in the past.");

            if (string.IsNullOrWhiteSpace(command.Summary))
                errors.Add("Summary is required.");

            return errors;
        }
    }
}
