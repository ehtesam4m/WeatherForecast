namespace WeatherForecast.Domain.Common;

public abstract class DomainEvent
{
    public DateTime DateOccurred { get; protected set; } = DateTime.UtcNow;
}

