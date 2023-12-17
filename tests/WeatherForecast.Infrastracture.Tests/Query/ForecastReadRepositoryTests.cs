using FluentAssertions;
using WeatherForecast.Domain.Aggregates.Forecast;
using WeatherForecast.Infrastracture.Query;
using WeatherForecast.Tests.Common.Builders;

namespace WeatherForecast.Infrastracture.Tests.Query
{
    public class ForecastReadRepositoryTests: TestBase
    {
        public ForecastReadRepositoryTests() {
            _testDb = new TestDatabaseInitializer();
        }

        [Fact]
        public async Task WhenForecastPresentInDB_FetchingForecastForWeek_ShouldReturnCorrectForecasts()
        {
            var forecast1 = new ForecastBuilder().WithDate(DateOnly.FromDateTime(DateTime.Now)).WithTemperature(40).Build();
            var forecast2 = new ForecastBuilder().WithDate(DateOnly.FromDateTime(DateTime.Now.AddDays(2))).WithTemperature(50).Build();
            var forecast3 = new ForecastBuilder().WithDate(DateOnly.FromDateTime(DateTime.Now.AddMonths(1))).WithTemperature(60).Build();

            using (var dbContext = new AppDbContext(_testDb.ContextOptions))
            {
                await dbContext.AddRangeAsync(forecast1, forecast2, forecast3);
                await dbContext.SaveChangesAsync();
            }

            using (var dbContext = new AppDbContext(_testDb.ContextOptions))
            {
                var forecastRepository = new ForecastReadRepository(dbContext);
                var result = await forecastRepository.GetForecastForWeek(DateOnly.FromDateTime(DateTime.Now).AddDays(-1));

                result.Count().Should().Be(2);

                result.Should().BeEquivalentTo(new List<Forecast>()
                    {
                        forecast1,
                        forecast2
                    }, options =>
                    {
                        options.ComparingByMembers<Forecast>();
                        options.Excluding(x => x.Id);
                        options.Excluding(x => x.DomainEvents);
                        return options;
                    });
            }
        }
    }
}
