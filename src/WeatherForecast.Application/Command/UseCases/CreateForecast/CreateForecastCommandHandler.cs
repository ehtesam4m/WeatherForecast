using MediatR;
using WeatherForecast.Application.Exceptions;
using WeatherForecast.Domain.Aggregates.ForecastAggregate;
using WeatherForecast.Domain.Aggregates.ForecastAggregate.AggregateRoot;
using WeatherForecast.Domain.Aggregates.ForecastAggregate.ValueObjects;
using WeatherForecast.Domain.Common;

namespace WeatherForecast.Application.Command.UseCases.CreateForecast
{
    public class CreateForecastCommandHandler(IForecastRepository _repository, IUnitOfWork _unitOfWork) : IRequestHandler<CreateForecastCommand>
    {
        public async Task Handle(CreateForecastCommand request, CancellationToken cancellationToken)
        {
            if (await _repository.GetForecastByDate(request.Date) != null)
                throw new EntityAlreadyExistsException("Forecast with this date already exists");

            var forecastDate = new ForecastDate(request.Date);
            var forecastTemperature = new ForecastTemperature(request.Temperature);
            var forecast = new Forecast(forecastDate, forecastTemperature);
            
            await _repository.CreateAsync(forecast, cancellationToken);
            await _unitOfWork.CompleteAsync();
        }
    }
}
