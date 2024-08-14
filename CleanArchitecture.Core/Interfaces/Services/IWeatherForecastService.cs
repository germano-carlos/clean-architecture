using CleanArchitecture.Core.Entities;

namespace CleanArchitecture.Core.Interfaces.Services;

public interface IWeatherForecastService
{
    WeatherForecast GenerateForecastForDate(DateOnly date);
    IEnumerable<WeatherForecast> GetWeeklyForecast();
}