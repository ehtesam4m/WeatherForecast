using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using WeatherForecast.Domain.Common;

namespace WeatherForecast.Domain.Aggregates.WeatherForecast.Events
{
    public class WeatherForecastCreatedEvent(DateOnly date, int temperature) : DomainEvent
    {
        public DateOnly Date { get; } = date;
        public int Temperature { get; } = temperature;
    }
}
