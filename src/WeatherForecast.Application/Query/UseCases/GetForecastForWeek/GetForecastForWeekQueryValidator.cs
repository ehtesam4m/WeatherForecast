using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
