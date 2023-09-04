using Application.Common.Interfaces.Database;
using Application.Common.Interfaces.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class WeatherForecastRepository : IWeatherForecastRepository
{
    private readonly IApplicationDbContext _context;

    public WeatherForecastRepository(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<WeatherForecast>> FindAllAsync()
    {
        return await _context.WeatherForecasts.ToListAsync();
    }

    public async Task<WeatherForecast?> FindByIdAsync(int id)
    {
        return await _context.WeatherForecasts.FindAsync(id);
    }

    public async Task<int> CreateAsync(WeatherForecast weatherForecast, CancellationToken cancellationToken)
    {
        _context.WeatherForecasts.Add(weatherForecast);
        return await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<int> UpdateAsync(WeatherForecast weatherForecast, CancellationToken cancellationToken)
    {
        _context.WeatherForecasts.Update(weatherForecast);
        return await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<int> DeleteAsync(int weatherForecastId, CancellationToken cancellationToken)
    {
        var weatherForecast = _context.WeatherForecasts.Find(weatherForecastId);
        if (weatherForecast == null) return default;
        _context.WeatherForecasts.Remove(weatherForecast);
        return await _context.SaveChangesAsync(cancellationToken);
    }

    public void Dispose()
    {
        _context.Dispose();
        GC.SuppressFinalize(this);
    }

    public Task<bool> IsWeatherForecastNotExistByDate(DateTime date, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<bool> IsWeatherForecastNotExistByDate(DateTime date, int id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

}
