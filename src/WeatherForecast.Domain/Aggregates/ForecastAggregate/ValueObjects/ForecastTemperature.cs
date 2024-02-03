using WeatherForecast.Domain.Common;
using WeatherForecast.Domain.Common.Execptions;

namespace WeatherForecast.Domain.Aggregates.ForecastAggregate.ValueObjects
{
    public class ForecastTemperature: ValueObject<ForecastTemperature>
    {
        public int Value { get; private set; }

        private ForecastTemperature() { }
        public ForecastTemperature(int temperature)
        {
            if (temperature < -60 || temperature > 60)
                throw new DomainValidationExeption("Temperature can not be less than -60 or greater than 60");
            Value = temperature;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
