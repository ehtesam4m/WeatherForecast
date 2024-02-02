using FluentAssertions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using WeatherForecast.API.Query;
using WeatherForecast.Application.Query.UseCases.GetForecastForWeek;
using WeatherForecast.Tests.Common;

namespace WeatherForecast.API.Tests.Query
{
    public class ForecastControllerTests
    {
        private readonly Mock<IMediator> _mediatorMock;

        public ForecastControllerTests()
        {
            _mediatorMock = new Mock<IMediator>();
        }

        [Theory, CustomAutoData]
        public async Task WhenHandlerReturnsData_GetForcastForWeek_ShouldReturnOKResultWithData(GetForecastForWeekQuery query, List<GetForecastForWeekQueryResult> result)
        {
            _mediatorMock
                .Setup(x => x.Send(query, It.IsAny<CancellationToken>()))
                .ReturnsAsync(result);
            
            var sut = new ForecastController(_mediatorMock.Object);
            var actualResult = await sut.GetForcastForWeek(query);

            actualResult.Should()
                  .BeOfType<OkObjectResult>()
                  .Which.Value.Should().Be(result);
        }
    }
}
