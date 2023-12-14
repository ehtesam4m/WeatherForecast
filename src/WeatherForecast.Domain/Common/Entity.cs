namespace WeatherForecast.Domain.Common;

public abstract class Entity : HasDomainEvents
{
  public int Id { get; set; }
}

public abstract class Entity<TId> : HasDomainEvents
  where TId : struct, IEquatable<TId>
{
  public TId Id { get; set; }
}

