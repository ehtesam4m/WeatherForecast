using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherForecast.Application.Command.UseCases.CreateForecast
{
    public record CreateForecastCommand (DateOnly Date, int Temperature): IRequest;
}
