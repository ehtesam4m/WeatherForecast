using MediatR;

namespace WeatherForecast.Application.Query.UseCases.GetForecastForWeek
{
    public record GetForecastForWeekQuery(DateOnly StartDate): IRequest<List<GetForecastForWeekQueryResult>>;

}
