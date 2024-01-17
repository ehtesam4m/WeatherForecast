using WeatherForecast.Domain.Common;
using WeatherForecast.Domain.Common.Execptions;

namespace WeatherForecast.Domain.Aggregates.Forecast.ValueObjects
{
    public class ForecastDate : ValueObject<ForecastDate>
    {
        public DateOnly Date { get; private set; }
        private ForecastDate() { }

        public ForecastDate(DateOnly date) {
            if (date < DateOnly.FromDateTime(DateTime.UtcNow))
                throw new DomainValidationExeption("Date can not be in the past");
            Date = date;
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Date;
        }
    }
}
