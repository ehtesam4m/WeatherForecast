using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherForecast.Domain.Aggregates.Forecast;
using WeatherForecast.Domain.Common;

namespace WeatherForecast.Application.Command.UseCases.CreateForecast
{
    public class CreateForecastCommandHandler (IForecastRepository _repository, IUnitOfWork _unitOfWork) : IRequestHandler<CreateForecastCommand>
    {
        public async Task Handle(CreateForecastCommand request, CancellationToken cancellationToken)
        {
            if (await _repository.GetForecastByDate(request.Date) != null)
                throw new InvalidOperationException("Forcast with this date already exists");

            var forecast = new Forecast(request.Date, request.Temperature);
            await _repository.CreateAsync(forecast, cancellationToken);
            await _unitOfWork.CompleteAsync();
        }
    }
}
