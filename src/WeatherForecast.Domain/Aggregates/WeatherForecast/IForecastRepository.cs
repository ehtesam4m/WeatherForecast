using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherForecast.Domain.Common;

namespace WeatherForecast.Domain.Aggregates.WeatherForecast
{
    public interface IForecastRepository: IRepository<Forecast>
    {
        Task<Forecast> GetForecastByDate(DateOnly date);
    }
}
