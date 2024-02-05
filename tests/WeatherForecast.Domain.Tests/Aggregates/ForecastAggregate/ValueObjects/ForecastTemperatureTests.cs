using FluentAssertions;
using WeatherForecast.Domain.Common.Execptions;

namespace WeatherForecast.Domain.Aggregates.ForecastAggregate.ValueObjects
{
    public class ForecastTemperatureTests
    {
        [Fact]
        public void WhenTemperatureLessThanMinus60_ForecastTemperatureCreation_ShouldThrowException()
        {
            var action = () => { new ForecastTemperature(-61); };

            action.Should().Throw<DomainValidationExeption>();
        }

        [Fact]
        public void WhenTemperatureGreaterThan60_ForecastTemperatureCreation_ShouldThrowException()
        {
            var action = () => { new ForecastTemperature(61); };

            action.Should().Throw<DomainValidationExeption>();
        }

        [Fact]
        public void WhenTemperatureBetweenMinus60And60_ForecastTemperatureCreation_ShouldCreateObjectWithCorrectValue()
        {
            var temperature = 20;

            var forecastTemperature = new ForecastTemperature(temperature);

            forecastTemperature.Value.Should().Be(temperature);
        }
    }
}
