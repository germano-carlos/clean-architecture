using System.Dynamic;
using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Interfaces.Repositories;
using CleanArchitecture.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.Repositories;

public class WeatherForecastRepository : IWeatherForecastRepository
{
    private readonly EFCoreDbContext _context;
    private readonly DbSet<WeatherForecast> _dbSet;

    public WeatherForecastRepository(EFCoreDbContext context)
    {
        _context = context;
        _dbSet = context.Set<WeatherForecast>();
    }

    public WeatherForecast? GetByDate(DateOnly date)
    {
        return _dbSet.SingleOrDefault(w => w.Date == date);
    }

    public WeatherForecast? GetById(int id)
    {
        return _dbSet.Find(id);
    }

    public IEnumerable<WeatherForecast> GetAll()
    {
        return _dbSet.ToList();
    }

    public void Add(WeatherForecast forecast)
    {
        _dbSet.Add(forecast);
    }

    public void Update(WeatherForecast forecast)
    {
        _dbSet.Update(forecast);
    }

    public void Delete(WeatherForecast forecast)
    {
        _dbSet.Remove(forecast);
    }
}