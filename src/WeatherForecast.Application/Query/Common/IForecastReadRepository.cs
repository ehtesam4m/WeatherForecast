using WeatherForecast.Domain.Aggregates.Forecast;

namespace WeatherForecast.Application.Query.Common
{
    public interface IForecastReadRepository
    {
        Task<List<Forecast>> GetForecastForWeek(DateOnly startDate);
    }
}
