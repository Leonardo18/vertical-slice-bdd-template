using Scalar.AspNetCore;
using VerticalSlice.BDD.Template.Features.CreateWeatherForecast;
using VerticalSlice.BDD.Template.Features.GetWeatherForecast;
using Wolverine;
using Wolverine.Http;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddWolverineHttp();
builder.Host.UseWolverine();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "OpenAPI V1");
    });

    app.UseReDoc(options =>
    {
        options.SpecUrl("/openapi/v1.json");
    });

    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.MapGetWeatherForecast();
app.MapCreateWeatherForecast();

app.MapWolverineEndpoints();

app.Run();

public partial class Program { }