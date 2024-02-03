using FluentAssertions;
using WeatherForecast.Domain.Aggregates.ForecastAggregate.AggregateRoot;
using WeatherForecast.Domain.Aggregates.ForecastAggregate.DomainEvents;
using WeatherForecast.Domain.Aggregates.ForecastAggregate.ValueObjects;
using WeatherForecast.Domain.Common.Extensions;

namespace WeatherForecast.Domain.Aggregates.ForecastAggregate.AggregateRoot
{
    public class ForecastTests
    {
        /*[Fact]
        public void WhenDateIsInThePast_ForecastCreation_ShouldThrowException()
        {
            var action = () => { new Forecast(DateOnly.FromDateTime(DateTime.Now.AddDays(-2)), 50); };
            action.Should().Throw<DomainValidationExeption>();
        }

        [Fact]
        public void WhenTemperatureLessThanMinus60_ForecastCreation_ShouldThrowException()
        {
            var action = () => { new Forecast(DateOnly.FromDateTime(DateTime.Now), -61); };
            action.Should().Throw<DomainValidationExeption>();
        }

        [Fact]
        public void WhenTemperatureGreaterThan60_ForecastCreation_ShouldThrowException()
        {
            var action = () => { new Forecast(DateOnly.FromDateTime(DateTime.Now), 61); };
            action.Should().Throw<DomainValidationExeption>();
        }*/

        [Fact]
        public void WhenParametersAreValid_ForecastCreation_ShouldRaiseForecastCreatedEvent()
        {
            var forecast = new Forecast(new ForecastDate(DateHelper.Today), new ForecastTemperature(50));

            forecast.DomainEvents.Count().Should().Be(1);
            forecast.DomainEvents.First().GetType().Should().Be(typeof(ForecastCreatedEvent));

        }
    }
}
