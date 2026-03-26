using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.Messages
{
    public class MessageDto
    {
        public Guid Id { get; set;}
        public string Content { get; set; }
        public string SentAt { get; set; }
        public bool IsEdited { get; set; }
        public bool IsDeleted { get; set; }
        public string SenderUsername { get; set;}
    }
}
