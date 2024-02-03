using WeatherForecast.Domain.Common;
using WeatherForecast.Domain.Common.Execptions;
using WeatherForecast.Domain.Common.Extensions;

namespace WeatherForecast.Domain.Aggregates.Forecast.ValueObjects
{
    public class ForecastDate : ValueObject<ForecastDate>
    {
        public DateOnly Value { get; private set; }
        private ForecastDate() { }

        public ForecastDate(DateOnly date) {
            if (date < DateHelper.Today)
                throw new DomainValidationExeption("Date can not be in the past");
            Value = date;
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
