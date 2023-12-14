using WeatherForecast.Domain.Common;
using WeatherForecast.Infrastracture;

namespace WeatherForecast.Infrastracture.Command
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _appDbContext;

        public UnitOfWork(AppDbContext databaseContext)
        {
            _appDbContext = databaseContext;
        }

        public async Task CompleteAsync()
        {
            await _appDbContext.SaveChangesAsync();

        }
    }
}
