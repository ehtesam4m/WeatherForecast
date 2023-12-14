using MediatR;
using Microsoft.AspNetCore.Mvc;
using WeatherForecast.Application.Command.UseCases.CreateForecast;

namespace WeatherForecast.API.Command
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

        [HttpPost]
        public async Task<IActionResult> Create(CreateForecastCommand command)
        {
            await _mediator.Send(command);
            return Created();
        }
    }
}
