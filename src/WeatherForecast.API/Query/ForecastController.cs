using MediatR;
using Microsoft.AspNetCore.Mvc;
using WeatherForecast.Application.Command.UseCases.CreateForecast;
using WeatherForecast.Application.Query.UseCases.GetForecastForWeek;

namespace WeatherForecast.API.Query
{
    [ApiController]
    [Route("[controller]")]
    public class ForecastController : ControllerBase
    {
        
        private readonly IMediator _mediator;

        public ForecastController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetForcastForWeek([FromQuery] GetForecastForWeekQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
