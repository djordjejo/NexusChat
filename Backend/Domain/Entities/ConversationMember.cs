using Domain.EnumMember;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ConversationMember
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid ConversationId { get; set; }
        public MemberRole Role { get; set; } = MemberRole.Member;
        public DateTime JoinedAt { get; set; }

        // Navigation properties
        public User User { get; set; } = null!;
        public Conversation Conversation { get; set; } = null!;
    }
}
