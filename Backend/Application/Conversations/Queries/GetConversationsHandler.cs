using Application.DTO;
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Persistence.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Application.Conversations.Queries
{
    public class GetConversationsHandler : IRequestHandler<GetConversationQuery, List<ConversationDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetConversationsHandler(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<List<ConversationDto>> Handle(GetConversationQuery query, CancellationToken cancellationToken)
        {
            var conversations = await _unitOfWork
           .ConversationMembers
           .GetByUserIdAsync(query.UserId);

            return conversations.Select(c => new ConversationDto
            {
                Id = c.Id,
                Name = c.Name,
                IsGroup = c.IsGroup,
                CreatedAt = c.CreatedAt
            }).ToList();

        }
    }
}
