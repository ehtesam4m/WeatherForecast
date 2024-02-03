using MediatR;
using WeatherForecast.Application.Exceptions;
using WeatherForecast.Domain.Aggregates.ForecastAggregate;
using WeatherForecast.Domain.Aggregates.ForecastAggregate.AggregateRoot;
using WeatherForecast.Domain.Aggregates.ForecastAggregate.ValueObjects;
using WeatherForecast.Domain.Common;

namespace WeatherForecast.Application.Command.UseCases.CreateForecast
{
    public class CreateForecastCommandHandler (IForecastRepository _repository, IUnitOfWork _unitOfWork) : IRequestHandler<CreateForecastCommand>
    {
        public async Task Handle(CreateForecastCommand request, CancellationToken cancellationToken)
        {
            if (await _repository.GetForecastByDate(request.Date) != null)
                throw new EntityAlreadyExistsException("Forcast with this date already exists");

            var forecast = new Forecast(new ForecastDate(request.Date), new ForecastTemperature(request.Temperature));
            await _repository.CreateAsync(forecast, cancellationToken);
            await _unitOfWork.CompleteAsync();
        }
    }
}
