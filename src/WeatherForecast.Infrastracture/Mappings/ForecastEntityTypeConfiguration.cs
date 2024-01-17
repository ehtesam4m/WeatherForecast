using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WeatherForecast.Domain.Aggregates.Forecast;

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
                cb.Property(x => x.Date).HasColumnName("Test_date").IsRequired();
            });
            builder.OwnsOne(e => e.Temperature, cb =>
            {
                cb.Property(x => x.Temperature).HasColumnName("Test_Temp").IsRequired();
            });
            builder.HasIndex(o => o.Date.Date).IsUnique();
        }
    }
}
