using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Interfaces;
using CleanArchitecture.Core.Interfaces.Repositories;
using CleanArchitecture.Infrastructure.Repositories;

namespace CleanArchitecture.Infrastructure.Persistence;

public class UnitOfWork : IUnitOfWork
{
    private readonly EFCoreDbContext _context;

    public UnitOfWork(EFCoreDbContext context)
    {
        _context = context;
    }

    private IWeatherForecastRepository _weatherForecasts;
    public IWeatherForecastRepository WeatherForecasts
    {
        get
        {
            return _weatherForecasts ??= new WeatherForecastRepository(_context);
        }
    }

    public void CommitAsync()
    {
        _context.SaveChanges();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}