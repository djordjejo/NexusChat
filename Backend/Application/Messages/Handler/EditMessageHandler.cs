using Application.DTO.Attachment;
using Application.DTO.Messages;
using Application.Messages.Command;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;
using System.Reflection;

namespace Application.Messages.Handler
{
    public class EditMessageHandler : IRequestHandler<EditMessageCommand, MessageDto>
    {
        private readonly IUnitOfWork _unitOfWork;

        public EditMessageHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<MessageDto> Handle(EditMessageCommand command, CancellationToken cancellationToken)
        {
            var message  = await _unitOfWork.Messages.GetByIdAsync(command.MessageId);
            if (message == null || message.IsDeleted == true)
                throw new KeyNotFoundException("Message not found.");

            if(message.SenderId != command.EditorId)
                throw new UnauthorizedAccessException("You can only edit your own messages.");
            var sender = await _unitOfWork.Users.GetByIdAsync(command.EditorId);

            message.Content = command.Content;
            message.IsEdited = true;

            await _unitOfWork.Messages.UpdateAsync(message);
            await _unitOfWork.Commit(cancellationToken);

            return new MessageDto
            {
                MessageId = message.Id,
                Content = message.Content,
                IsEdited = message.IsEdited.Value,
                SentAt = message.SentAt,       
                SenderUsername = sender.Username,
                Attachments = new List<AttachmentDto>()
            };
        }
    }
}
