using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repository
{
    public class ConversationMembersRepository : Repository<ConversationMember>, IConversationMemberRepository
    {
        private readonly AppDbContext dbContext;

        public ConversationMembersRepository(AppDbContext context) : base(context)
        {
            dbContext = context;
        }

        public async Task<IEnumerable<Conversation>> GetByUserIdAsync(Guid id)
        {
            var result = await dbContext.ConversationMembers
                .Where(x => x.UserId.Equals(id))
                .Include(x => x.Conversation)
                .Select(x => x.Conversation)
                .ToListAsync() ;

            return result;
        }
    }
}