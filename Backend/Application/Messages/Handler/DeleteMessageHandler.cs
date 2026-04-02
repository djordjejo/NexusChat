using Application.DTO.Messages;
using Application.Messages.Command;
using Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Messages.Handler
{
    public class DeleteMessageHandler : IRequestHandler<DeleteMessageCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteMessageHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> Handle(DeleteMessageCommand command, CancellationToken cancellationToken)
        {
            var message = await _unitOfWork.Messages.GetByIdAsync(command.MessageId);
            if (message == null)
                return false;

            if (message.SenderId != command.SenderId)
                throw new Exception("Nemate dozvolu da obrišete ovu poruku");

            message.IsDeleted = true;
            await _unitOfWork.Messages.UpdateAsync(message);
            await _unitOfWork.Commit(cancellationToken);

            return true;
        }
    }
}
