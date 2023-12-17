using AutoFixture;
using AutoFixture.Xunit2;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherForecast.Application.Command.UseCases.CreateForecast;
using WeatherForecast.Application.Query.Common;
using WeatherForecast.Application.Query.UseCases.GetForecastForWeek;
using WeatherForecast.Domain.Aggregates.Forecast;
using WeatherForecast.Domain.Common;
using WeatherForecast.Tests.Common;
using WeatherForecast.Tests.Common.Builders;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WeatherForecast.Application.Tests.Query
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
            var foreCasts1 = new ForecastBuilder().WithTemperature(40).Build();
            var foreCasts2 = new ForecastBuilder().WithDate(DateOnly.FromDateTime(DateTime.Now.AddDays(2))).WithTemperature(-10).Build();

            _repository.Setup(x => x.GetForecastForWeek(query.StartDate)).ReturnsAsync(
                    new List<Forecast> {
                        foreCasts1,
                        foreCasts2
                    }
                );
            
            var sut = new GetForecastForWeekQueryHandler(_repository.Object);
            var result = await sut.Handle(query, It.IsAny<CancellationToken>());

            result.Should().BeEquivalentTo(new List<GetForecastForWeekQueryResult> {
                new GetForecastForWeekQueryResult(foreCasts1.Date, ForecastConverter.GetWeatherCondition(foreCasts1.Temperature)),
                new GetForecastForWeekQueryResult(foreCasts2.Date, ForecastConverter.GetWeatherCondition(foreCasts2.Temperature)),
            });
        }
    }
}
