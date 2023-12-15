using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherForecast.Application.Query.Common
{
    public static class ForecastConverter
    {
        private static IDictionary<string, (int, int)> _weatherConditions = new Dictionary<string, (int, int)>() {
            {"Freezing", (-60, -10) },
            {"Bracing", (-9, 0) },
            {"Chilli", (1, 5) },
            {"Cool", (6, 10) },
            {"Mild", (11, 15) },
            {"Warm", (16, 25) },
            {"Balmy", (26, 30) },
            {"Hot", (31, 40) },
            {"Sweltering", (41, 45) },
            {"Scorching", (46, 60) },
        };

        public static string GetWeatherCondition(int temperature)
        {
            var weatherCondtion = string.Empty;
            foreach (KeyValuePair<string, (int, int)> entry in _weatherConditions)
            {
                if (temperature >= entry.Value.Item1 && temperature <= entry.Value.Item2)
                { 
                    weatherCondtion = entry.Key;
                    break;
                }    
            }
            return weatherCondtion;
        }
    }
}
