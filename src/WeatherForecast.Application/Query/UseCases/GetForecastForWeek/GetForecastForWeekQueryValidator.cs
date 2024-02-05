using FluentValidation;
using WeatherForecast.Domain.Common.Extensions;

namespace WeatherForecast.Application.Query.UseCases.GetForecastForWeek
{
    public class GetForecastForWeekQueryValidator : AbstractValidator<GetForecastForWeekQuery>
    {
        public GetForecastForWeekQueryValidator() {
            RuleFor(x => x.StartDate).GreaterThanOrEqualTo(DateHelper.Today)
                .WithMessage("Start date can not be in the past");
        }
    }
}
