using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Interfaces;
using CleanArchitecture.Core.Interfaces.Repositories;
using CleanArchitecture.Core.Interfaces.Services;

namespace CleanArchitecture.Application.Services;

public class WeatherForecastService : IWeatherForecastService
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };
    
    private readonly IUnitOfWork _unitOfWork;
    
    public WeatherForecastService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public WeatherForecast GenerateForecastForDate(DateOnly date)
    {
        var forecast = new WeatherForecast
        {
            Date = date,
            TemperatureC = CalculateTemperature(date),
            Summary = GenerateSummary(),
        };

        _unitOfWork.WeatherForecasts.Add(forecast);
        _unitOfWork.CommitAsync();
        return forecast;
    }
    public IEnumerable<WeatherForecast> GetWeeklyForecast()
    {
        return _unitOfWork.WeatherForecasts.GetAll();
    }
    private int CalculateTemperature(DateOnly date)
    {
        return Random.Shared.Next(-20, 55);
    }
    private string GenerateSummary()
    {
        var summaries = new[] { "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching" };
        return summaries[Random.Shared.Next(summaries.Length)];
    }
}