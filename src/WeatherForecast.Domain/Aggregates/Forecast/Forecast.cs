using WeatherForecast.Domain.Aggregates.Forecast.Events;
using WeatherForecast.Domain.Aggregates.Forecast.ValueObjects;
using WeatherForecast.Domain.Common;
using WeatherForecast.Domain.Common.Execptions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WeatherForecast.Domain.Aggregates.Forecast
{
    public class Forecast : Entity, IAggregateRoot
    {
        public ForecastDate Date { get; private set;}
        public ForecastTemperature Temperature { get; private set; }

        private Forecast() { }
        public Forecast(ForecastDate date, ForecastTemperature temperature)
        {
            Date = date;
            Temperature = temperature;

            var weatherForecastCreatedEvent = new ForecastCreatedEvent(Date.Value, Temperature.Value);
            RegisterDomainEvent(weatherForecastCreatedEvent);
        }
    }
}
