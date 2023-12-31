﻿using WeatherForecast.Domain.Common;
namespace WeatherForecast.Domain.Aggregates.Forecast.Events;

public class ForecastCreatedEvent(DateOnly date, int temperature) : DomainEvent
{
    public DateOnly Date { get; } = date;
    public int Temperature { get; } = temperature;
}

