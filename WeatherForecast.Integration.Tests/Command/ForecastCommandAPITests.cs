using FluentAssertions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WeatherForecast.Application.Command.UseCases.CreateForecast;

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
    }
}
