using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class MessageAttachment
    {
        public int Id { get; set; }
        public string FileName { get; set; } = string.Empty;
        public string FileUrl { get; set; } = string.Empty;
        public long FileSize { get; set; }        // u bajtovima
        public string FileType { get; set; } = string.Empty;  // "image/png", "application/pdf"...
        public DateTime UploadedAt { get; set; }
        public AttachmentType AttachmentType { get; set; }
        public int MessageId { get; set; }
        public Message Message { get; set; } = null!;
    }
}
