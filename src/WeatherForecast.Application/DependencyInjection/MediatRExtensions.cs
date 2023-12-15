using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using WeatherForecast.Application.Behaviors;

namespace WeatherForecast.Application.DependencyInjection
{
    public static class MediatRExtensions
    {
        public static IServiceCollection AddMediatRDependencies(this IServiceCollection services, Assembly assembly)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(assembly));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            return services;
        }
    }
}
