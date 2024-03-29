﻿using AutoFixture;
using Moq;
using WeatherForecast.Application.Command.UseCases.CreateForecast;
using WeatherForecast.Domain.Aggregates.ForecastAggregate;
using WeatherForecast.Domain.Common;
using FluentAssertions;
using WeatherForecast.Tests.Common;
using WeatherForecast.Tests.Common.Builders;
using WeatherForecast.Application.Exceptions;
using WeatherForecast.Domain.Aggregates.ForecastAggregate.ValueObjects;
using WeatherForecast.Domain.Common.Extensions;
using WeatherForecast.Domain.Aggregates.ForecastAggregate.AggregateRoot;


namespace WeatherForecast.Application.Tests.Command.UseCases.CreateForecast
{
    public class CreateForecastCommandHandlerTests
    {
        private readonly IFixture _fixture;
        private readonly Mock<IForecastRepository> _repository;
        private readonly Mock<IUnitOfWork> _unitOfWork;

        public CreateForecastCommandHandlerTests()
        {
            _fixture = CustomFixture.Create();
            _repository = new Mock<IForecastRepository>();
            _unitOfWork = new Mock<IUnitOfWork>();
        }

        [Fact]
        public async Task WhenCommandIsValid_Handler_ShouldCreateCorrectForecast()
        {
            var command = _fixture.Build<CreateForecastCommand>()
                            .With(x => x.Date, DateHelper.Today)
                            .With(x => x.Temperature, 5)
                            .Create();
            var mockForecastDate = new ForecastDate(command.Date);
            var mockForecastTemperature = new ForecastTemperature(command.Temperature);

            var sut = new CreateForecastCommandHandler(_repository.Object, _unitOfWork.Object);
            await sut.Handle(command, It.IsAny<CancellationToken>());

            _repository.Verify(x => x.CreateAsync(It.Is<Forecast>(x => x.Date.Equals(mockForecastDate)
            && x.Temperature.Equals(mockForecastTemperature)),
            It.IsAny<CancellationToken>()), Times.Once);

            _unitOfWork.Verify(x => x.CompleteAsync(), Times.Once);

        }

        [Theory, CustomAutoData]
        public async Task WhenDateAlreadyExists_Handler_ShouldReurnInvalidOperationException(CreateForecastCommand command)
        {
            _repository.Setup(x => x.GetForecastByDate(command.Date)).ReturnsAsync(new ForecastBuilder().Build());

            var sut = new CreateForecastCommandHandler(_repository.Object, _unitOfWork.Object);
            var action = () => sut.Handle(command, It.IsAny<CancellationToken>());

            await action.Should().ThrowAsync<EntityAlreadyExistsException>();
        }
    }
}
