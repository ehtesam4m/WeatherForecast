using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherForecast.Domain.Aggregates.WeatherForecast;

namespace WeatherForecast.Infrastracture.Command
{
    public class ForecastRepository(AppDbContext appDbContext) : Repository<Forecast>(appDbContext), IForecastRepository
    {
        public async Task<Forecast> GetForecastByDate(DateOnly date)
        {
            return await repoDbSet.Where(x => x.Date == date).FirstOrDefaultAsync();
        }
    }
}
