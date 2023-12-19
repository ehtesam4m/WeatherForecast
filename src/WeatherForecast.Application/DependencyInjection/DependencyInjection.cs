using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace WeatherForecast.Application.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatRDependencies();
            return services;
        }
    }
}
