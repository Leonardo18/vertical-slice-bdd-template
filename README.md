# Vertical Slice BDD Template

This project is a **proof of concept (PoC)** that combines:

- ✅ **Vertical Slice Architecture** — feature-first structure (no traditional layers)
- ✅ **Minimal API (ASP.NET Core 9)** — clean and lightweight REST endpoints
- ✅ **Wolverine** — command/message handling framework
- ✅ **Reqnroll** — BDD-style testing with Gherkin and SpecFlow syntax
- ✅ **Central Package Management** — consistent NuGet versioning across the solution

---

## 📁 Project Structure

```text
vertical-slice-bdd-template/
├── build/
│   ├── Directory.Build.props
│   └── Directory.Packages.props
├── src/
│   └── VerticalSlice.BDD.Template/
│       ├── Features/
│       │   ├── CreateWeatherForecast/
│       │   │   ├── CreateWeatherForecast.cs
│       │   │   ├── CreateWeatherForecastEndpoint.cs
│       │   │   └── CreateWeatherForecastHandler.cs
│       │   └── GetWeatherForecast/
│       │       ├── GetWeatherForecast.cs
│       │       ├── GetWeatherForecastEndpoint.cs
│       │       └── GetWeatherForecastHandler.cs
│       ├── appsettings.json
│       └── Program.cs
├── tests/
│   └── VerticalSlice.BDD.Template.Tests/
│       ├── Features/
│       │   └── Weather/
│       │       ├── CreateWeatherForecast.feature
│       │       ├── CreateWeatherForecastSteps.cs
│       │       ├── GetWeatherForecast.feature
│       │       └── GetWeatherForecastSteps.cs
├── VerticalSlice.BDD.Template.sln
└── README.md
```
---

## 🚀 Technologies Used

| Technology                     | Purpose                            |
|-------------------------------|-------------------------------------|
| [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)       | Runtime & Minimal API              |
| [Wolverine](https://github.com/JasperFx/wolverine)                   | CQRS, messaging, command handling |
| [Reqnroll](https://github.com/reqnroll/Reqnroll)                     | BDD with Gherkin syntax            |
| [xUnit](https://xunit.net)                                           | Test runner                        |
| [Shouldly](https://shouldly.readthedocs.io/)                         | Fluent assertions                  |
| [Microsoft.AspNetCore.Mvc.Testing](https://www.nuget.org/packages/Microsoft.AspNetCore.Mvc.Testing/) | API testing support                |

---

## ✅ Features Implemented

### `GET /weatherforecast`
- Returns 5 days of mocked weather data
- Covered by BDD tests

### `POST /weatherforecast`
- Accepts a JSON body with forecast data
- Returns:
  - `201 Created` on success
  - `400 Bad Request` on invalid temperature
- Also covered by BDD tests (happy and failure paths)

---

## 🧪 Running the Tests

```bash
dotnet test
```

The tests are located in the `tests/VerticalSlice.BDD.Template.Tests` project.

Reqnroll will discover and run the `.feature` files with their associated step definitions.

---

## 🧰 How to Use This Template

This repository can be used as a base to explore:

- Vertical Slice design with Wolverine message handlers
- End-to-end testing using Reqnroll + xUnit
- Minimal API patterns with dependency injection and endpoint mapping
- Fluent validation and feature-level separation of responsibilities

---

## 📚 Useful Links

- [Vertical Slice Architecture with Minimal APIs](https://blog.treblle.com/minimal-api-with-vertical-slice-architecture/)
- [Wolverine Documentation](https://wolverine.netlify.app/)
- [Reqnroll GitHub](https://github.com/reqnroll/Reqnroll)
- [Shouldly Documentation](https://shouldly.readthedocs.io/en/latest/)

---

## 🧑‍💻 Author

Created by [@Leonardo18](https://github.com/Leonardo18)

Feel free to fork this repository, open issues, or submit pull requests.
