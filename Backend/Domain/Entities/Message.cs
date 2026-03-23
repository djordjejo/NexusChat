using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Message
    {
        public Guid Id { get; set; }
        public string Content { get; set; } = string.Empty;
        public DateTime SentAt { get; set; }
        public bool? IsEdited { get; set; }
        public bool? IsDeleted { get; set; } 
        public Guid SenderId { get; set; }
        public Guid ConversationId { get; set; }

        public User Sender { get; set; } = null!;
        public Conversation Conversation { get; set; } = null!;
        public ICollection<MessageAttachment> Attachments { get; set; } = new List<MessageAttachment>();
    }
}
