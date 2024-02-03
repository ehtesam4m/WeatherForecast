using FluentAssertions;
using Moq;
using WeatherForecast.Application.Query.Common;
using WeatherForecast.Application.Query.UseCases.GetForecastForWeek;
using WeatherForecast.Domain.Aggregates.Forecast;
using WeatherForecast.Tests.Common;
using WeatherForecast.Tests.Common.Builders;
using WeatherForecast.Domain.Aggregates.Forecast.ValueObjects;
using WeatherForecast.Domain.Common.Extensions;

namespace WeatherForecast.Application.Tests.Query.UseCases.GetForecastForWeek
{
    public class GetForecastForWeekQueryHandlerTests
    {
        private readonly Mock<IForecastReadRepository> _repository;

        public GetForecastForWeekQueryHandlerTests()
        {
            _repository = new Mock<IForecastReadRepository>();
        }

        [Theory, CustomAutoData]
        public async Task WhenRepositoryReturnsData_Handler_ShouldReturnCorrectlyMappedData(GetForecastForWeekQuery query)
        {
            var foreCasts1 = new ForecastBuilder().WithTemperature(new ForecastTemperature(40)).Build();
            var foreCasts2 = new ForecastBuilder()
                                .WithDate(new ForecastDate(DateHelper.Tomorrow))
                                .WithTemperature(new ForecastTemperature(-10))
                                .Build();

            _repository.Setup(x => x.GetForecastForWeek(query.StartDate)).ReturnsAsync(
                    new List<Forecast> {
                        foreCasts1,
                        foreCasts2
                    }
                );

            var sut = new GetForecastForWeekQueryHandler(_repository.Object);
            var result = await sut.Handle(query, It.IsAny<CancellationToken>());

            result.Should().BeEquivalentTo(new List<GetForecastForWeekQueryResult> {
                new GetForecastForWeekQueryResult(foreCasts1.Date.Value, ForecastConverter.GetWeatherCondition(foreCasts1.Temperature.Value)),
                new GetForecastForWeekQueryResult(foreCasts2.Date.Value, ForecastConverter.GetWeatherCondition(foreCasts2.Temperature.Value)),
            });
        }
    }
}
