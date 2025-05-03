using Microsoft.AspNetCore.Mvc.Testing;
using Reqnroll;
using Shouldly;
using System.Net.Http.Json;

namespace VerticalSlice.BDD.Template.BddTests.Features.Weather
{
    [Binding]
    public class GetWeatherForecastSteps
    {
        private readonly HttpClient _client;
        private HttpResponseMessage? _response;
        private WeatherForecast[]? _result;

        public GetWeatherForecastSteps()
        {
            var factory = new WebApplicationFactory<Program>();
            _client = factory.CreateClient();
        }

        [When(@"I GET ""(.*)""")]
        public async Task WhenIGet(string url)
        {
            _response = await _client.GetAsync(url);
        }

        [Then(@"the response status code for the get weather forecast should be (\d+)")]
        public void ThenStatusCodeShouldBe(int statusCode)
        {
            ((int)_response!.StatusCode).ShouldBe(statusCode);
        }

        [Then(@"the response should contain (\d+) weather forecasts")]
        public async Task ThenShouldContainForecasts(int expectedCount)
        {
            _result = await _response!.Content.ReadFromJsonAsync<WeatherForecast[]>();
            _result!.Length.ShouldBe(expectedCount);
        }

        public record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary);
    }
}
