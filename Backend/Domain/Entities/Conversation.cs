using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Conversation
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }        
        public bool IsGroup { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid CreatedById { get; set; }

        public User CreatedBy { get; set; } = null!;
        public ICollection<ConversationMember> Members { get; set; } = new List<ConversationMember>();
        public ICollection<Message> Messages { get; set; } = new List<Message>();
    }
}
