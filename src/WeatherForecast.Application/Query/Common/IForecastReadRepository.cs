using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherForecast.Domain.Aggregates.WeatherForecast;

namespace WeatherForecast.Application.Query.Common
{
    public interface IForecastReadRepository
    {
        Task<List<Forecast>> GetForecastForWeek(DateOnly startDate);
    }
}
