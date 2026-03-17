using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Message
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public DateTime SentAt { get; set; }
        public bool IsEdited { get; set; }
        public bool IsDeleted { get; set; }

        public Guid SenderId { get; set; }
        public User Sender { get; set; }
        public string ConversationId { get; set; }
        public Conversation Conversation { get; set; }
    }
}
