using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WeatherForecast.Application.Query.Common;
using WeatherForecast.Domain.Aggregates.Forecast;
using WeatherForecast.Domain.Common;
using WeatherForecast.Infrastracture.Command;
using WeatherForecast.Infrastracture.Query;

namespace WeatherForecast.Infrastracture.Common.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(o => o.UseSqlServer(configuration["ConnectionStrings:DB"]));
            services.AddScoped<IForecastRepository, ForecastRepository>();
            services.AddScoped<IForecastReadRepository, ForecastReadRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
