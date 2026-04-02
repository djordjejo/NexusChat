using Application.DTO.Messages;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Application.Messages.Command
{
    public class DeleteMessageCommand : IRequest<bool>
    {
        public Guid MessageId { get; set; }
        public Guid SenderId { get; set; }
    }
}
