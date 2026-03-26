using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IConversationMemberRepository : IRepository<ConversationMember>
    {
        public Task<IEnumerable<Conversation>> GetConversationsAsync(Guid id);
        public Task<Conversation> GetConversationAsync(Guid id);

    }
}