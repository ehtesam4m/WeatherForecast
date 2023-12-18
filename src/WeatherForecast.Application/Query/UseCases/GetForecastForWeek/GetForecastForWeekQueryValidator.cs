using FluentValidation;

namespace WeatherForecast.Application.Query.UseCases.GetForecastForWeek
{
    public class GetForecastForWeekQueryValidator : AbstractValidator<GetForecastForWeekQuery>
    {
        public GetForecastForWeekQueryValidator() {
            RuleFor(x => x.StartDate).GreaterThanOrEqualTo(DateOnly.FromDateTime(DateTime.Now))
                .WithMessage("Start date can not be in the past");
        }
    }
}
