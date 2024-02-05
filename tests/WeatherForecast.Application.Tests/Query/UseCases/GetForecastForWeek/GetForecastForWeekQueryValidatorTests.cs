using FluentValidation.TestHelper;
using WeatherForecast.Application.Query.UseCases.GetForecastForWeek;
using WeatherForecast.Domain.Common.Extensions;

namespace WeatherForecast.Application.Tests.Query.UseCases.GetForecastForWeek
{
    public class GetForecastForWeekQueryValidatorTests
    {
        private GetForecastForWeekQueryValidator _validator;

        public GetForecastForWeekQueryValidatorTests()
        {
            _validator = new GetForecastForWeekQueryValidator();
        }

        [Fact]
        public void WhenStartDateIsInThePast_Validator_ShouldHaveError()
        {
            GetForecastForWeekQuery query = new GetForecastForWeekQuery(DateHelper.Yesterday);
            var result = _validator.TestValidate(query);
            result.ShouldHaveValidationErrorFor(x => x.StartDate);
        }
    }
}
