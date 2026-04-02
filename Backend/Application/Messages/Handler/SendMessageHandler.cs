using Application.DTO.Attachment;
using Application.DTO.Messages;
using Application.Messages.Command;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.Messages.Handler
{
    public class SendMessageHandler : IRequestHandler<SendMessageCommand, MessageDto>
    {
        private readonly IUnitOfWork _unitOfWork;

        public SendMessageHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<MessageDto> Handle(SendMessageCommand command, CancellationToken cancellationToken)
        {
            var conversation = await _unitOfWork.Conversations.GetByIdAsync(command.ConversationId);
            if (conversation == null)
                throw new Exception("Konverzacija ne postoji");

            var message = new Message
            {
                ConversationId = command.ConversationId,
                SenderId = command.senderId,
                Content = command.Content,
                SentAt = DateTime.UtcNow,
                IsEdited = false,
                IsDeleted = false
            };

            await _unitOfWork.Messages.AddAsync(message);
            await _unitOfWork.Commit(cancellationToken);

            var sender = await _unitOfWork.Users.GetByIdAsync(command.senderId);

            return new MessageDto
            {
                MessageId = message.Id,
                Content = message.Content,
                SentAt = message.SentAt,
                SenderUsername = sender?.Username ?? "Unknown",
                IsEdited = message.IsEdited.Value,
                Attachments = new List<AttachmentDto>()
            };
        }
    }
}
