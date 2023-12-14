using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherForecast.Application.Query.Common;

namespace WeatherForecast.Application.Query.UseCases.GetForecastForWeek
{
    public class GetForecastForWeekQueryHandler(IForecastReadRepository _forecastReadRepository) : IRequestHandler<GetForecastForWeekQuery, List<GetForecastForWeekQueryResult>>
    {
        public async Task<List<GetForecastForWeekQueryResult>> Handle(GetForecastForWeekQuery request, CancellationToken cancellationToken)
        {
            var forecasts = await _forecastReadRepository.GetForecastForWeek(request.StartDate);

            return forecasts.Select(x => new GetForecastForWeekQueryResult(x.Date, 
                ForecastConverter.GetWeatherCondition(x.Temperature))).ToList();
        }
    }
}
