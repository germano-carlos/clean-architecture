using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Interfaces.Repositories;

namespace CleanArchitecture.Core.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IWeatherForecastRepository WeatherForecasts { get; }
    void CommitAsync();
}