using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WeatherForecast.Domain.Aggregates.WeatherForecast;

namespace Project.Infrastructure.Mappings
{
    internal class ForecastEntityTypeConfiguration : IEntityTypeConfiguration<Forecast>
    {
        public void Configure(EntityTypeBuilder<Forecast> builder)
        {
            builder.ToTable("Forecasts").HasKey(o => o.Id);
            builder.Property(o => o.Id).UseIdentityColumn();
            builder.Property(e => e.Date).IsRequired();
            builder.Property(e => e.Temperature).IsRequired();
            builder.HasIndex(o => o.Date).IsUnique();
        }
    }
}
