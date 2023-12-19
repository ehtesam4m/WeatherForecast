using System.Data.Common;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace WeatherForecast.Infrastracture.Tests
{

    public sealed class TestDatabaseInitializer : IDisposable
    {
        private readonly DbConnection _connection;
        public TestDatabaseInitializer()
        {
            _connection = CreateInMemoryDatabase();
            ContextOptions = new DbContextOptionsBuilder<AppDbContext>()
                .UseSqlite(_connection)
                .Options;
            Seed();
        }
        public DbContextOptions<AppDbContext> ContextOptions { get; }

        private static DbConnection CreateInMemoryDatabase()
        {
            var connection = new SqliteConnection("Filename=:memory:;Foreign Keys=False");

            connection.Open();

            return connection;
        }

        public void Dispose() => _connection.Dispose();

        private void Seed()
        {
            using (var context = new AppDbContext(ContextOptions))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
            }
        }


    }
}
