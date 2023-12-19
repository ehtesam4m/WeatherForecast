namespace WeatherForecast.Domain.Common;

public interface IUnitOfWork
{
    Task CompleteAsync();
}

