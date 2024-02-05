using Microsoft.EntityFrameworkCore;
using WeatherForecast.Application.Query.Common;
using WeatherForecast.Domain.Aggregates.ForecastAggregate.AggregateRoot;

namespace WeatherForecast.Infrastracture.Query
{
    public class ForecastReadRepository(AppDbContext _dbContext) : IForecastReadRepository
    {
        public async Task<List<Forecast>> GetForecastForWeek(DateOnly startDate)
        {
           return await _dbContext.Forecasts.Where(x => x.Date.Value >= startDate && x.Date.Value <= startDate.AddDays(6)).ToListAsync();
        }
    }
}
