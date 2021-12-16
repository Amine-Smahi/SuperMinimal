using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SuperMinimal.Models;

namespace SuperMinimal.Features;
using Ardalis.ApiEndpoints;

public class GetWeatherForecast : EndpointBaseAsync
    .WithoutRequest
    .WithResult<WeatherForecast[]>
{
    [HttpPost("api/GetWeatherForecast")]
    public override Task<WeatherForecast[]> HandleAsync(CancellationToken cancellationToken = new())
    {
        string[] summaries = {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        }; 
        
        return Task.FromResult(Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = summaries[Random.Shared.Next(summaries.Length)]
            })
            .ToArray());
    }
}