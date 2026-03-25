using Application.DTO;
using Domain.Entities;
using Domain.EnumMember;
using Domain.Interfaces;
using MediatR;

namespace Application.Conversations.Commands.CreateConversation;

public class CreateConversationHandler : IRequestHandler<CreateConversationCommand, ConversationDto>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateConversationHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ConversationDto> Handle(
        CreateConversationCommand command,
        CancellationToken cancellationToken)
    {
        if (command == null)
            throw new Exception("Conversation obj is null");

        var conversation = new Conversation
        {
            Name = command.Name,
            IsGroup = command.IsGroup,
            CreatedById = command.CreatedById,
            CreatedAt = DateTime.UtcNow
        };

        await _unitOfWork.Conversations.AddAsync(conversation);
        await _unitOfWork.Commit(cancellationToken);

        // 2. Dodaj kreatora kao Admin člana
        var creatorMember = new ConversationMember
        {
            UserId = command.CreatedById,
            ConversationId = conversation.Id,
            Role = MemberRole.Admin,
            JoinedAt = DateTime.UtcNow
        };

        await _unitOfWork.ConversationMembers.AddAsync(creatorMember);

        // 3. Dodaj ostale članove
        foreach (var memberId in command.MemberIds)
        {
            if (memberId == command.CreatedById) continue; // kreator vec dodat

            var member = new ConversationMember
            {
                UserId = memberId,
                ConversationId = conversation.Id,
                Role = MemberRole.Member,
                JoinedAt = DateTime.UtcNow
            };

            await _unitOfWork.ConversationMembers.AddAsync(member);
        }

        await _unitOfWork.Commit(cancellationToken);

        // 4. Vrati DTO
        return new ConversationDto
        {
            Id = conversation.Id,
            Name = conversation.Name,
            IsGroup = conversation.IsGroup,
            CreatedAt = conversation.CreatedAt
        };
    }
}