using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherForecast.Application.Query.UseCases.GetForecastForWeek
{
    public record GetForecastForWeekQueryResult(DateOnly Date, string WeatherCondition);
 
}
