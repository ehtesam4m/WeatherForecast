namespace WeatherForecast.Application.Query.UseCases.GetForecastForWeek
{
    public record GetForecastForWeekQueryResult(DateOnly Date, string WeatherCondition);
 
}
