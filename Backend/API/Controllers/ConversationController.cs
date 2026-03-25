using Application.Conversations.Commands.CreateConversation;
using Application.Conversations.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;


namespace API.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class ConversationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ConversationController(IMediator mediator)
        {
            this._mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetConversations()
        {
            var userId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

            var result = await _mediator.Send(new GetConversationQuery(userId));
            return Ok(result);
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateChat(CreateConversationCommand command)
        {
            var userId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

            command.CreatedById = userId;

            var result = await _mediator.Send(command);
            return Created("", result);
        }
    }
}
