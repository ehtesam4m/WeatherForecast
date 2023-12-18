using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Logging;
using WeatherForecast.Domain.Common;
using WeatherForecast.Infrastracture;

namespace WeatherForecast.Infrastracture.Command
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _appDbContext;
        private readonly ILogger<UnitOfWork> _logger;

        public UnitOfWork(AppDbContext databaseContext, ILogger<UnitOfWork> logger)
        {
            _appDbContext = databaseContext;
            _logger = logger;
        }

        public async Task CompleteAsync()
        {
            var entitiesWithEvents = _appDbContext.ChangeTracker.Entries<Entity>()
                .Select(e => e.Entity)
                .Where(e => e.DomainEvents.Any())
                .ToArray();

            foreach (var entity in entitiesWithEvents)
            {
                foreach (var item in entity.DomainEvents)
                {
                    _logger.LogInformation($"{item.GetType().Name} created at {item.DateOccurred}");
                }
            }

            await _appDbContext.SaveChangesAsync();


        }
    }
}
