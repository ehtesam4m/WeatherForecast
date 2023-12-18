using FluentAssertions;
using System.Net;
using WeatherForecast.Infrastracture;
using WeatherForecast.Tests.Common.Builders;

namespace WeatherForecast.Integration.Tests.Query
{
    public class ForecastQueryAPITests: TestBase
    {
        [Fact]
        public async Task WhenQueryIsValid_GettingForecastForWeek_ShouldReturn200OKResult()
        {
            var forecast1 = new ForecastBuilder().WithDate(DateOnly.FromDateTime(DateTime.Now)).WithTemperature(40).Build();
            var forecast2 = new ForecastBuilder().WithDate(DateOnly.FromDateTime(DateTime.Now.AddDays(2))).WithTemperature(50).Build();

            using (var dbContext = new AppDbContext(_testDb.ContextOptions))
            {
                await dbContext.AddRangeAsync(forecast1, forecast2);
                await dbContext.SaveChangesAsync();
            }

            var response = await _client.GetAsync($"/forecast?startDate={forecast1.Date.ToString("yyyy-MM-dd")}");

            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task WhenQueryIsNotValid_GettingForecastForWeek_ShouldReturn400BadRequest()
        {
            var response = await _client.GetAsync($"/forecast?startDate={DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd")}");

            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }
    }
}
