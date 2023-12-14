using Microsoft.EntityFrameworkCore;
using WeatherForecast.Application.Query.Common;
using WeatherForecast.Domain.Aggregates.WeatherForecast;

namespace WeatherForecast.Infrastracture.Query
{
    public class ForecastReadRepository(AppDbContext _dbContext) : IForecastReadRepository
    {
        public async Task<List<Forecast>> GetForecastForWeek(DateOnly startDate)
        {
           return await _dbContext.Forecasts.Where(x => x.Date >= startDate && x.Date <= startDate.AddDays(6)).ToListAsync();
        }
    }
}
