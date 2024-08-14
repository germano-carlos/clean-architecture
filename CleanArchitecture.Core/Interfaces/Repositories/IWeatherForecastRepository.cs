using CleanArchitecture.Core.Entities;

namespace CleanArchitecture.Core.Interfaces.Repositories;

public interface IWeatherForecastRepository : IRepository<WeatherForecast>
{
    WeatherForecast GetByDate(DateOnly date);
}