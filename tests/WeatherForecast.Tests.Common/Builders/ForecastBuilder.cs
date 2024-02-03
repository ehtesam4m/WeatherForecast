using WeatherForecast.Domain.Aggregates.Forecast;
using WeatherForecast.Domain.Aggregates.Forecast.ValueObjects;
using WeatherForecast.Domain.Common.Extensions;

namespace WeatherForecast.Tests.Common.Builders
{
    public class ForecastBuilder
    {
        private ForecastDate _forecastDate = new ForecastDate(DateHelper.Today);
        private ForecastTemperature _forecasttemperature = new ForecastTemperature(5);

        public ForecastBuilder WithDate(ForecastDate value) {
            _forecastDate = value;
            return this;
        }
        public ForecastBuilder WithTemperature(ForecastTemperature value)
        {
            _forecasttemperature = value;
            return this;
        }

        public Forecast Build() {
            return new Forecast(_forecastDate, _forecasttemperature);
        }
    }
}
