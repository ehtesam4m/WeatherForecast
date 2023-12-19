namespace WeatherForecast.Domain.Common;

public interface IRepository<T> where T : IAggregateRoot
{
    Task CreateAsync(T entity, CancellationToken cancellationToken = default);
    Task UpdateAsync(T entity);
}

