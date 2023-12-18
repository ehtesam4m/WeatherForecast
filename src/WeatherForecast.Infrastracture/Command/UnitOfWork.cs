using Microsoft.Extensions.Logging;
using WeatherForecast.Domain.Common;

namespace WeatherForecast.Infrastracture.Command
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _appDbContext;
        private readonly ILogger<UnitOfWork> _logger;
        private readonly IEventSerializer _eventSerializer;

        public UnitOfWork(AppDbContext databaseContext, ILogger<UnitOfWork> logger, IEventSerializer eventSerializer)
        {
            _appDbContext = databaseContext;
            _logger = logger;
            _eventSerializer = eventSerializer;
        }

        public async Task CompleteAsync()
        {
            var domainEvents = _appDbContext.ChangeTracker.Entries<Entity>()
                .Select(e => e.Entity)
                .Where(e => e.DomainEvents.Any())
                .SelectMany(x => x.DomainEvents).ToList();

            foreach (var item in domainEvents)
            {
                _logger.LogInformation($"{item.GetType().Name} created at {item.DateOccurred} with data: {_eventSerializer.Serialize(item)}");
            }

            await _appDbContext.SaveChangesAsync();
        }
    }
}
