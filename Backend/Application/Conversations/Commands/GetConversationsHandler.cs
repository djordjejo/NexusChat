using Application.Conversations.Queries;
using Application.DTO;
using Application.DTO.Conversation;
using Application.DTO.Member;
using Application.DTO.Messages;
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Persistence.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Application.Conversations.Commands
{
    public class GetConversationsHandler : IRequestHandler<GetConversationsQuery, List<ConversationsDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetConversationsHandler(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<List<ConversationsDto>> Handle(GetConversationsQuery query, CancellationToken cancellationToken)
        {

            var conversations = await _unitOfWork.ConversationMembers.GetConversationsAsync(query.UserId);

            var result = conversations.Select(x => new ConversationsDto
            {
                ConversationName = x.Name,

            }).ToList();

            return result;
        }


    }
}
