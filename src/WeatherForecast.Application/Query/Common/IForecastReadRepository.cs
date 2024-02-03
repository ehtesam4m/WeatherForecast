using WeatherForecast.Domain.Aggregates.ForecastAggregate.AggregateRoot;

namespace WeatherForecast.Application.Query.Common
{
    public interface IForecastReadRepository
    {
        Task<List<Forecast>> GetForecastForWeek(DateOnly startDate);
    }
}
