﻿using AutoFixture;
using Moq;
using WeatherForecast.Application.Command.UseCases.CreateForecast;
using WeatherForecast.Domain.Aggregates.Forecast;
using WeatherForecast.Domain.Common;
using FluentAssertions;
using WeatherForecast.Tests.Common;
using WeatherForecast.Tests.Common.Builders;


namespace WeatherForecast.Application.Tests.Command
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
                            .With(x => x.Date, DateOnly.FromDateTime(DateTime.Now))
                            .With(x => x.Temperature, 5)
                            .Create();
            
            Forecast savedAggregate = null;
            _repository.Setup(x => x.CreateAsync(It.IsAny<Forecast>(), It.IsAny<CancellationToken>()))
                .Callback((Forecast aggregate, CancellationToken cancellationToken) =>
                {
                    savedAggregate = aggregate;
                }
                ).Returns(Task.CompletedTask);

            _unitOfWork.Setup(x => x.CompleteAsync()).Returns(Task.CompletedTask);

            var sut = new CreateForecastCommandHandler(_repository.Object, _unitOfWork.Object);
            await sut.Handle(command, It.IsAny<CancellationToken>());

            _unitOfWork.Verify(x => x.CompleteAsync(), Times.Once);
            savedAggregate.Date.Should().Be(command.Date);
            savedAggregate.Temperature.Should().Be(command.Temperature);
        }

        [Fact]
        public async Task WhenDateAlreadyExists_Handler_ShouldReurnInvalidOperationException()
        {
            var command = _fixture.Create<CreateForecastCommand>();
            _repository.Setup(x => x.GetForecastByDate(command.Date)).ReturnsAsync(new ForecastBuilder().Build());
            
            var sut = new CreateForecastCommandHandler(_repository.Object, _unitOfWork.Object);
            var action = () => sut.Handle(command, It.IsAny<CancellationToken>());
            
            await action.Should().ThrowAsync<InvalidOperationException>();
        }
    }
}