using System.Linq.Expressions;

namespace WeatherForecast.Domain.Common;

public interface IRepository<T> where T : IAggregateRoot
{
    Task CreateAsync(T entity, CancellationToken cancellationToken = default);
    Task UpdateAsync(T entity);
    Task<T> GetByIdAsync<TId>(TId id, CancellationToken cancellationToken = default) where TId : notnull;
}

