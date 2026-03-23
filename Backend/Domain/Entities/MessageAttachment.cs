using Domain.EnumMember;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class MessageAttachment
    {
        public Guid Id { get; set; }
        public string FileName { get; set; } = string.Empty;
        public string FileUrl { get; set; } = string.Empty;
        public long FileSize { get; set; }
        public string ContentType { get; set; } = string.Empty;
        public AttachmentType AttachmentType { get; set; }
        public DateTime UploadedAt { get; set; }
        public Guid MessageId { get; set; }
        public Message Message { get; set; }
    }
}
