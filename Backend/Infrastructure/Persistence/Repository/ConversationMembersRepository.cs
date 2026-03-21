using Domain.Interfaces;

namespace Infrastructure.Persistence.Repository
{
    public class ConversationMembersRepository : Repository<ConversationMembersRepository>, IConversationMemberRepository
    {
        public ConversationMembersRepository(AppDbContext context) : base(context)
        {
        }
    }
}