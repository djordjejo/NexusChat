using Application.Users.Commands.Register;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Update.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Users.Commands.Queries.LogIn;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("registera ")]
        public async Task<IActionResult> Registry(RegisterCommand command) {

            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> LogIn(LoginQuery query) {
          
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
