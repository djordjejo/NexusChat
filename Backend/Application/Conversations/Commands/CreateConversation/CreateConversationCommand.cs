using Application.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Conversations.Commands.CreateConversation
{
    public class CreateConversationCommand : IRequest<ConversationDto>
    {
        public string? Name { get; set; }        // null za 1-na-1
        public bool IsGroup { get; set; }
        public Guid CreatedById { get; set; }
        public List<Guid> MemberIds { get; set; } = new();
    }
}
