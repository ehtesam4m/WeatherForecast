using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherForecast.Domain.Aggregates.Forecast;
using WeatherForecast.Domain.Aggregates.Forecast.Events;

namespace WeatherForecast.Domain.Tests.Aggregates
{
    public class ForecastAggregateTests
    {
        [Fact]
        public void WhenDateIsInThePast_ForecastCreation_ShouldThrowException()
        {
            var action = () => { new Forecast(DateOnly.FromDateTime(DateTime.Now.AddDays(-2)), 50); };
            action.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void WhenTemperatureLessThanMinus60_ForecastCreation_ShouldThrowException()
        {
            var action = () => { new Forecast(DateOnly.FromDateTime(DateTime.Now), -61); };
            action.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void WhenTemperatureGreaterThan60_ForecastCreation_ShouldThrowException()
        {
            var action = () => { new Forecast(DateOnly.FromDateTime(DateTime.Now), 61); };
            action.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void WhenParametersAreValid_ForecastCreation_ShouldRaiseForecastCreatedEvent()
        {
            var forecast = new Forecast(DateOnly.FromDateTime(DateTime.Now), 50);
            
            forecast.DomainEvents.Count().Should().Be(1);
            forecast.DomainEvents.First().GetType().Should().Be(typeof(ForecastCreatedEvent));
            
        }
    }
}
