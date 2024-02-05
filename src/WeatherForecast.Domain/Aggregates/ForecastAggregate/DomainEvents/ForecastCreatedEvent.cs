using WeatherForecast.Domain.Common;
namespace WeatherForecast.Domain.Aggregates.ForecastAggregate.DomainEvents;

public class ForecastCreatedEvent(DateOnly date, int temperature) : DomainEvent
{
    public DateOnly Date { get; } = date;
    public int Temperature { get; } = temperature;
}

