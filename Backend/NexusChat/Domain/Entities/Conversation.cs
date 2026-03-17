using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Conversation
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public bool IsGroup { get; set; }
        public DateTime CreatedAt { get; set; }
        public int CreatedById { get; set; }

        public User CreatedBy { get; set; }
        public ICollection<ConversationMember> Members { get; set; }
        public ICollection<Message> Messages { get; set; }
    }
}
