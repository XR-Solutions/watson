using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Watson.Core.Common;
using Watson.Core.Enums;

namespace Watson.Core.Entities
{
    /// <summary>
    /// A single chat message
    /// </summary>
    public class ChatMessage : BaseEntity
    {
        /// <summary>
        /// The date and time of when this message was sent
        /// </summary>
        public DateTime DateTime { get; set; }

        /// <summary>
        /// The ID for the user who sent this message
        /// </summary>
        public string UserId { get; set; } = string.Empty;

        /// <summary>
        /// The chat id that this message belongs to
        /// </summary>
        public Guid ChatSessionId { get; set; }

        /// <summary>
        /// The chat this message belongs to
        /// </summary>
        public virtual ChatSession? ChatSession { get; set; }

        /// <summary>
        /// Content of the message
        /// </summary>
        public string Content { get; set; } = string.Empty;

        /// <summary>
        /// The role of the author of this message
        /// </summary>
        public ChatAuthorRole AuthorRole { get; set; }

        /// <summary>
        /// The type of message that this is
        /// </summary>
        public ChatMessageType MessageType { get; set; }

        /// <summary>
        /// Citations used in this message
        /// </summary>
        /// TODO: restore
        //public IEnumerable<ChatCitation> Citations { get; set; } = Enumerable.Empty<ChatCitation>();
    }
}
