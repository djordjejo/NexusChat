using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IMessageRepository : IRepository<Message> {
        Task<IEnumerable<Message>> GetByConversationIdAsync(int conversationId, int page, int pageSize);

    }
}