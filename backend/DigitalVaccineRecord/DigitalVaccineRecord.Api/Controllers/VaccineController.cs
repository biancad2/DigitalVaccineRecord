using DigitalVaccineRecord.Api.Commands.User;
using DigitalVaccineRecord.Api.Commands.Vaccine;
using DigitalVaccineRecord.Core.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DigitalVaccineRecord.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VaccineController : Controller
    {
        private readonly IMediator _mediator;

        public VaccineController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Get([FromQuery] GetAllVaccinesCommand request)
        {
            var response = _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Get(Guid id)
        {
            var request = new GetVaccineCommand() { Id = id };
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody]AddVaccineCommand request)
        {
            await _mediator.Send(request);
            return Created();
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Put([FromQuery] UpdateVaccineCommand request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(Guid id)
        {
            var request = new DeleteVaccineCommand() { Id = id };
            var result = await _mediator.Send(request);
            return Ok(result);
        }
    }
}
