using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace Infrastructure.Persistence.Repository
{
    public class ConversationsRepository : Repository<Conversation>, IConversationRepository
    {
       
        public ConversationsRepository(AppDbContext context) : base(context)
        {
        }

    }
}