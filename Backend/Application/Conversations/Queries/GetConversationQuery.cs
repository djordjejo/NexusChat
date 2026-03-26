using Application.DTO;
using Application.DTO.Conversation;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Conversations.Queries
{
    public class GetConversationQuery : IRequest<ConversationDto>
    {
        public Guid ConversationId { get; set; }

        public GetConversationQuery(Guid conversationId)
        {
            ConversationId = conversationId;
        }
    }
}
