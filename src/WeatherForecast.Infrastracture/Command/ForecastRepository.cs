using Microsoft.EntityFrameworkCore;
using WeatherForecast.Domain.Aggregates.Forecast;

namespace WeatherForecast.Infrastracture.Command
{
    public class ForecastRepository(AppDbContext appDbContext) : Repository<Forecast>(appDbContext), IForecastRepository
    {
        public async Task<Forecast> GetForecastByDate(DateOnly date)
        {
            return await repoDbSet.Where(x => x.Date.Value == date).FirstOrDefaultAsync();
        }
    }
}
