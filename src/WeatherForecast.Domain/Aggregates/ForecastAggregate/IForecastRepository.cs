using WeatherForecast.Domain.Aggregates.ForecastAggregate.AggregateRoot;
using WeatherForecast.Domain.Common;

namespace WeatherForecast.Domain.Aggregates.ForecastAggregate

{
    public interface IForecastRepository: IRepository<Forecast>
    {
        Task<Forecast> GetForecastByDate(DateOnly date);
    }
}
