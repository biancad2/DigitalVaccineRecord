using DigitalVaccineRecord.Api.Commands.User;
using DigitalVaccineRecord.Core.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DigitalVaccineRecord.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IUserService _userService;

        public UserController(IMediator mediator/*, IUserService userService*/)
        {
            this._mediator = mediator;
            //this._userService = userService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Get([FromQuery] GetAllUsersCommand request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var request = new GetUserCommand() { Id = id };
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody]AddUserCommand request)
        {
            await _mediator.Send(request);
            return Created();
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromQuery] UpdateUserCommand request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("dose")]
        public async Task<IActionResult> AddDose([FromBody] AddUserDoseCommand request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var request = new DeleteUserCommand() { Id = id };
            var result = await _mediator.Send(request);
            return Ok(result);
        }
    }
}
