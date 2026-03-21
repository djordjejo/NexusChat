using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUnitOfWork
    {
        IUserRepository Users { get; }
        IConversationRepository Conversations { get; }
        IMessageRepository Messages { get; }
        IConversationMemberRepository ConversationMembers { get; }
        IMessageAttachmentRepository MessageAttachments { get; }
        public Task<int> Commit();
    }
}
