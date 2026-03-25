using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IConversationMemberRepository : IRepository<ConversationMember>
    {
        public Task<IEnumerable<Conversation>> GetByUserIdAsync(Guid id);

    }
}