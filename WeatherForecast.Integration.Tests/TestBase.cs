using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.TestHost;
using WeatherForecast.Infrastracture;
using Microsoft.AspNetCore.Hosting;

namespace WeatherForecast.Integration.Tests
{
    public  class TestBase : IDisposable
    {
        protected TestDatabaseInitializer _testDb;
        protected HttpClient _client;
        protected WebApplicationFactory<Program> _factory;

        public TestBase()
        {
            _testDb = new TestDatabaseInitializer();
            _factory = new WebApplicationFactory<Program>();
            _factory = _factory.WithWebHostBuilder(builder =>
            {
                builder.UseEnvironment("Development");

                _ = builder.ConfigureTestServices(services =>
                {
                    services.AddScoped(_ => new AppDbContext(_testDb.ContextOptions));
                });
            });
            _client = _factory.CreateClient();
        }

        public void Dispose()
        {
            _testDb.Dispose();
            _factory.Dispose();
            _client.Dispose();
        }
    }
}
