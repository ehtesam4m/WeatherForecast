using FluentAssertions;
using WeatherForecast.Infrastracture.Command;
using WeatherForecast.Tests.Common.Builders;

namespace WeatherForecast.Infrastracture.Tests.Command
{
    public class ForecastRepositoryTests : TestBase
    {
        public ForecastRepositoryTests()
        {
            _testDb = new TestDatabaseInitializer();
        }

        [Fact]
        public async Task WhenForecastPresentInDB_FetchingForecastByDate_ShouldReturnCorrectForecast()
        {

            var forecast = new ForecastBuilder().Build();
            using (var dbContext = new AppDbContext(_testDb.ContextOptions))
            {
                await dbContext.AddAsync(forecast);
                await dbContext.SaveChangesAsync();
            }

            using (var dbContext = new AppDbContext(_testDb.ContextOptions))
            {
                var forecastRepository = new ForecastRepository(dbContext);
                var result = await forecastRepository.GetForecastByDate(forecast.Date);

                result.Date.Should().Be(forecast.Date);
                result.Temperature.Should().Be(forecast.Temperature);
            }

        }
    }
}
