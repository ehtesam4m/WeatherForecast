using System.ComponentModel.DataAnnotations.Schema;

namespace WeatherForecast.Domain.Common;

public abstract class HasDomainEvents
{
  private List<DomainEvent> _domainEvents = new();
  [NotMapped]
  public IEnumerable<DomainEvent> DomainEvents => _domainEvents.AsReadOnly();

  protected void RegisterDomainEvent(DomainEvent domainEvent) => _domainEvents.Add(domainEvent);
  protected void ClearDomainEvents() => _domainEvents.Clear();

}

