using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherForecast.Domain.Common.Extensions
{
    public static class DateHelper
    {
        public static DateOnly Today
        {
            get { return DateOnly.FromDateTime(DateTime.UtcNow); }
        }

        public static DateOnly Yesterday
        {
            get { return DateOnly.FromDateTime(DateTime.UtcNow.AddDays(-1)); }
        }

        public static DateOnly Tomorrow
        {
            get { return DateOnly.FromDateTime(DateTime.UtcNow.AddDays(1)); }
        }
    }
}
