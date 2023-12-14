using System.Reflection.Metadata.Ecma335;
using WeatherForecast.Domain.Aggregates.WeatherForecast.Events;
using WeatherForecast.Domain.Common;

namespace WeatherForecast.Domain.Aggregates.WeatherForecast
{
    internal class WeatherForecast : Entity, IAggregateRoot
    {
        public DateOnly Date { get; private set;}
        public int Temperature { get; private set; }

        public WeatherForecast(DateOnly date, int temperature)
        {
            SetDate(date);
            SetTemperature(temperature);

            var weatherForecastCreatedEvent = new WeatherForecastCreatedEvent(Date, Temperature);
            RegisterDomainEvent(weatherForecastCreatedEvent);
        }

        private void SetDate(DateOnly date)
        {
            if (date < DateOnly.FromDateTime(DateTime.UtcNow))
                throw new ArgumentException("Date can not be in the past");
            Date = date;
        }

        private void SetTemperature(int temparature)
        {
            if (temparature < -60 || temparature > 60)
                throw new ArgumentException("Temparature can not be less than -60 or greater than 60");
            Temperature = temparature;
        }
    }
}
