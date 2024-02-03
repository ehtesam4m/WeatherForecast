using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WeatherForecast.Domain.Aggregates.ForecastAggregate.AggregateRoot;

namespace Project.Infrastructure.Mappings
{
    internal class ForecastEntityTypeConfiguration : IEntityTypeConfiguration<Forecast>
    {
        public void Configure(EntityTypeBuilder<Forecast> builder)
        {
            builder.ToTable("Forecasts").HasKey(o => o.Id);
            builder.Property(o => o.Id).UseIdentityColumn();
            builder.OwnsOne(e => e.Date, cb =>
            {
                cb.Property(x => x.Value).HasColumnName("ForecastDate").IsRequired();
                cb.HasIndex(x => x.Value).IsUnique();
            });
            builder.OwnsOne(e => e.Temperature, cb =>
            {
                cb.Property(x => x.Value).HasColumnName("ForecastTemperature").IsRequired();
            });
        }
    }
}
