namespace WeatherForecast.Domain.Common.Execptions;
public class DomainValidationExeption : Exception
{
    public DomainValidationExeption()
    {
    }

    public DomainValidationExeption(string message) : base(message)
    {
    }
}