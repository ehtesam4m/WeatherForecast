using FluentAssertions;
using Newtonsoft.Json;
using System.Net;
using System.Text;
using WeatherForecast.Application.Command.UseCases.CreateForecast;
using WeatherForecast.Infrastracture;
using WeatherForecast.Tests.Common.Builders;

namespace WeatherForecast.Integration.Tests.Command
{
    public class ForecastQueryAPITests: TestBase
    {
        [Fact]
        public async Task WhenCommandIsValid_CreatingForecast_ShouldReturnNoContentStatus()
        {
            var response = await _client.PostAsync("/forecast",
                new StringContent(JsonConvert.SerializeObject(new CreateForecastCommand(DateOnly.FromDateTime(DateTime.Now), 10)), 
                Encoding.UTF8, "application/json")
                );

            response.StatusCode.Should().Be(HttpStatusCode.NoContent);
        }

        [Fact]
        public async Task WhenDateAreadyExists_CreatingForecast_ShouldReturn409Conflict()
        {
            var forecast = new ForecastBuilder().WithDate(DateOnly.FromDateTime(DateTime.Now)).WithTemperature(40).Build();

            using (var dbContext = new AppDbContext(_testDb.ContextOptions))
            {
                await dbContext.AddAsync(forecast);
                await dbContext.SaveChangesAsync();
            }
            var response = await _client.PostAsync("/forecast",
                new StringContent(JsonConvert.SerializeObject(new CreateForecastCommand(forecast.Date, 10)),
                Encoding.UTF8, "application/json")
                );

            response.StatusCode.Should().Be(HttpStatusCode.Conflict);
        }
    }
}
