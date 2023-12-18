namespace WeatherForecast.Domain.Common;

public interface IEventSerializer
{
    string Serialize<TEvent>(TEvent domainEvent) where TEvent : DomainEvent;
}
