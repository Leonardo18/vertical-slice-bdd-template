using Microsoft.AspNetCore.Mvc.Testing;
using Reqnroll;
using Shouldly;
using System.Net.Http.Json;
using System.Text.Json;

namespace VerticalSlice.BDD.Template.BddTests.Features.Weather
{
    [Binding]
    public class CreateWeatherForecastSteps
    {
        private readonly HttpClient _client;
        private HttpResponseMessage? _response;
        private object? _payload;

        public CreateWeatherForecastSteps()
        {
            var factory = new WebApplicationFactory<Program>();
            _client = factory.CreateClient();
        }

        [Given(@"a new weather forecast with:")]
        public void GivenANewWeatherForecastWith(Table table)
        {
            var row = table.Rows[0];

            _payload = new
            {
                date = DateOnly.Parse(row["date"]),
                temperatureC = int.Parse(row["temperatureC"]),
                summary = row["summary"]
            };
        }

        [When(@"I POST it to ""(.*)""")]
        public async Task WhenIPostItTo(string url)
        {
            _response = await _client.PostAsJsonAsync(url, _payload);
        }

        [Then(@"the response status code for the create weather forecast should be (\d+)")]
        public void ThenStatusCodeShouldBe(int expected)
        {
            ((int)_response!.StatusCode).ShouldBe(expected);
        }

        [Then(@"the response should contain the summary ""(.*)""")]
        public async Task ThenResponseShouldContainSummary(string expectedSummary)
        {
            var json = await _response!.Content.ReadFromJsonAsync<JsonElement>();
            var summary = json.GetProperty("summary").GetString();

            summary.ShouldBe(expectedSummary);
        }

        [Then(@"the response should contain an error with message ""(.*)""")]
        public async Task ThenResponseShouldContainErrorMessage(string expectedMessage)
        {
            var json = await _response!.Content.ReadFromJsonAsync<JsonElement>();

            var errors = json.GetProperty("errors").EnumerateArray().Select(e => e.GetString()).ToList();

            errors.ShouldContain(expectedMessage);
        }
    }
}
