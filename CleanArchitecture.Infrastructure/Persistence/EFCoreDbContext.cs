using CleanArchitecture.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.Persistence;

public class EFCoreDbContext : DbContext
{
    public DbSet<WeatherForecast> WeatherForecasts { get; set; }

    public EFCoreDbContext(DbContextOptions<EFCoreDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configurações adicionais de entidades, se necessário
    }
}