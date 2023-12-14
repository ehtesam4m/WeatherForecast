using System.Linq.Expressions;
using WeatherForecast.Domain.Common;

namespace WeatherForecast.Infrastracture;

    public class Repository<T> : IRepository<T> where T : IAggregateRoot
{
    protected readonly DbSet<T> repoDbSet;
    protected readonly DataBaseContext dbContext;
    protected Repository(DataBaseContext databaseContext)
    {
        dbContext = databaseContext;
        repoDbSet = databaseContext.Set<T>();
    }

    public async Task CreateAsync(T entity, CancellationToken cancellationToken=default)
    {
        await repoDbSet.AddAsync(entity, cancellationToken);
    }

    public async Task UpdateAsync(T entity)
    {
        repoDbSet.Update(entity);

        await Task.CompletedTask;
    }

    public async Task<T> GetAsync<TId>(TId id, CancellationToken cancellationToken = default)
    {
        return await repoDbSet.FindAsync(id);
    }

}

