using Domain.Entities;
using Domain.Interfaces;

namespace Infrastructure.Persistence.Repository
{
    public class ConversationsRepository : Repository<Conversation>, IConversationRepository
    {
        public ConversationsRepository(AppDbContext context) : base(context)
        {
        }
    }
}