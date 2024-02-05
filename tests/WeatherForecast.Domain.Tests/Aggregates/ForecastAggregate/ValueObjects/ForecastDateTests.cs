using FluentAssertions;
using WeatherForecast.Domain.Common.Execptions;
using WeatherForecast.Domain.Common.Extensions;

namespace WeatherForecast.Domain.Aggregates.ForecastAggregate.ValueObjects
{
    public class ForecastDateTests
    {
        [Fact]
        public void WhenDateIsInThePast_ForecastDateCreation_ShouldThrowException()
        {
            var action = () => { new ForecastDate(DateHelper.Yesterday); };
            action.Should().Throw<DomainValidationExeption>();
        }

        [Fact]
        public void WhenDateIsPresent_ForecastDateCreation_ShouldCreateForecastWithCorrectDate()
        {
            var forecastDate = new ForecastDate(DateHelper.Today);
            forecastDate.Value.Should().Be(DateHelper.Today);
        }

        [Fact]
        public void WhenDateIsInFuture_ForecastDateCreation_ShouldCreateObjectWithCorrectValue()
        {
            var forecastDate = new ForecastDate(DateHelper.Tomorrow);
            forecastDate.Value.Should().Be(DateHelper.Tomorrow);
        }
    }
}
