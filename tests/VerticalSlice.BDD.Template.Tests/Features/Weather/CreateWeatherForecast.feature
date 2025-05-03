Feature: Create Weather Forecast

Scenario: Successfully create a weather forecast
	Given a new weather forecast with:
		| date       | temperatureC | summary |
		| 2025-05-05 | 25           | Sunny   |
	When I POST it to "/weatherforecast"
	Then the response status code for the create weather forecast should be 201
	And the response should contain the summary "Sunny"

Scenario: Invalid temperature returns 400
	Given a new weather forecast with:
		| date       | temperatureC | summary |
		| 2025-05-05 | -999         | Extreme |
	When I POST it to "/weatherforecast"
	Then the response status code for the create weather forecast should be 400
	And the response should contain an error with message "TemperatureC must be between -50 and 60."
