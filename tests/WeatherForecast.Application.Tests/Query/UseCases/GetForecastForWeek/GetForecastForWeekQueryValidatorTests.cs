using FluentAssertions.Extensions;
using FluentValidation.TestHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherForecast.Application.Query.UseCases.GetForecastForWeek;

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
            GetForecastForWeekQuery query = new GetForecastForWeekQuery(DateOnly.FromDateTime(DateTime.Now.AddDays(-1)));
            var result = _validator.TestValidate(query);
            result.ShouldHaveValidationErrorFor(x => x.StartDate);
        }
    }
}
