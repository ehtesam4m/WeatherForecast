using AutoFixture.Xunit2;
using FluentAssertions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using WeatherForecast.API.Command;
using WeatherForecast.Application.Command.UseCases.CreateForecast;
using WeatherForecast.Tests.Common;

namespace WeatherForecast.API.Tests.Command
{
    public class ForecastControllerTests
    {
        private readonly Mock<IMediator> _mediatorMock;

        public ForecastControllerTests()
        {
            _mediatorMock = new Mock<IMediator>();
        }

        [Theory, CustomAutoData]
        public async Task Create_ShouldSendCorrectCommandAndReturnNoContent(CreateForecastCommand command)
        {
            var sut = new ForecastController(_mediatorMock.Object);
            var actualResult = await sut.Create(command);

            _mediatorMock.Verify(x => x.Send(command, It.IsAny<CancellationToken>()), Times.Once);
            actualResult.Should().BeOfType<NoContentResult>();
        }
    }
}
