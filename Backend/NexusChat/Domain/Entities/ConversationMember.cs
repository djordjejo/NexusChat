using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class ConversationMember
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ConversationId { get; set; }
        public MemberRole Role { get; set; }   
        public DateTime JoinedAt { get; set; }

        public User User { get; set; }
        public Conversation Conversation { get; set; }

    }
}
