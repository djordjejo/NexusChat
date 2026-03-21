using Domain.Entities;
using Domain.Interfaces;

namespace Infrastructure.Persistence.Repository
{
    public class MessageAttachmentsRepository : Repository<MessageAttachment>, IMessageAttachmentRepository
    {
        public MessageAttachmentsRepository(AppDbContext context) : base(context)
        {
        }
    }
}