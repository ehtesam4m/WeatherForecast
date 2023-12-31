using Microsoft.EntityFrameworkCore;
using WeatherForecast.Domain.Common;

namespace WeatherForecast.Infrastracture.Command;

public abstract class Repository<T> : IRepository<T> where T : class, IAggregateRoot
{
    protected readonly DbSet<T> repoDbSet;
    protected readonly AppDbContext dbContext;
    protected Repository(AppDbContext databaseContext)
    {
        dbContext = databaseContext;
        repoDbSet = databaseContext.Set<T>();
    }

    public async Task CreateAsync(T entity, CancellationToken cancellationToken = default)
    {
        await repoDbSet.AddAsync(entity, cancellationToken);
    }

    public async Task UpdateAsync(T entity)
    {
        repoDbSet.Update(entity);

        await Task.CompletedTask;
    }

}

