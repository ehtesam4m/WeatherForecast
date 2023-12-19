using WeatherForecast.Domain.Common;

namespace WeatherForecast.Domain.Aggregates.Forecast

{
    public interface IForecastRepository: IRepository<Forecast>
    {
        Task<Forecast> GetForecastByDate(DateOnly date);
    }
}
