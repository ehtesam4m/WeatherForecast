using Newtonsoft.Json;
using WeatherForecast.Domain.Common;

namespace WeatherForecast.Infrastracture
{
    public class EventSerilizer : IEventSerializer
    {
        public string Serialize<TEvent>(TEvent domainEvent) where TEvent : DomainEvent
        {
            string serializedEvent = JsonConvert.SerializeObject(domainEvent, Newtonsoft.Json.Formatting.Indented,
                 new JsonSerializerSettings
                 {
                     ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                 });

            return serializedEvent;
        }
    }
}
