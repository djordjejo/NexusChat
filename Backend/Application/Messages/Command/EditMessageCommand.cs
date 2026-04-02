using Application.DTO.Messages;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Messages.Command
{
    public class EditMessageCommand : IRequest<MessageDto>
    { 
        public Guid MessageId { get; set; }
        public Guid EditorId { get; set; }
        public string Content { get; set; }
    }
}
