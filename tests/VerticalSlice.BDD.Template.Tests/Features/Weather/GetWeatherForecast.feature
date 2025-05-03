Feature: Weather Forecast

  Scenario: Get weather forecast
    When I GET "/weatherforecast"
    Then the response status code for the get weather forecast should be 200
    And the response should contain 5 weather forecasts