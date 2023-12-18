using WeatherForecast.Domain.Aggregates.Forecast;

namespace WeatherForecast.Tests.Common.Builders
{
    public class ForecastBuilder
    {
        private DateOnly _date = DateOnly.FromDateTime(DateTime.Now);
        private int _temperature = 5;

        public ForecastBuilder WithDate(DateOnly value) {
            _date = value;
            return this;
        }
        public ForecastBuilder WithTemperature(int value)
        {
            _temperature = value;
            return this;
        }

        public Forecast Build() {
            return new Forecast(_date, _temperature);
        }
    }
}
