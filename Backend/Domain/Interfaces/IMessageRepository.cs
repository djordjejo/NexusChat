using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IMessageRepository : IRepository<Message> {
        public Task<IEnumerable<Message>> GetByConversationIdAsync(Guid conversationId, int page, int pageSize);
    }
}