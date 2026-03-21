using Domain.Entities;
using Domain.Interfaces;

namespace Infrastructure.Persistence.Repository
{
    public class MessagesRepository : Repository<Message>, IMessageRepository
    {
        private readonly AppDbContext _context;

        public MessagesRepository(AppDbContext context ) : base (context)
        {
            _context = context;
        }

        public Task<IEnumerable<Message>> GetByConversationIdAsync(int conversationId, int page, int pageSize)
        {
            throw new NotImplementedException();
        }
    }
}