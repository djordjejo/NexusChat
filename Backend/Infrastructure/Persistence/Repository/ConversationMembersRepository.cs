using Domain.Entities;
using Domain.Interfaces;

namespace Infrastructure.Persistence.Repository
{
    public class ConversationMembersRepository : Repository<ConversationMember>, IConversationMemberRepository
    {
        public ConversationMembersRepository(AppDbContext context) : base(context)
        {
        }
    }
}