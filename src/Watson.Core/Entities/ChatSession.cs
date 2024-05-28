using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Watson.Core.Common;

namespace Watson.Core.Entities
{
    /// <summary>
    /// An entire chat session
    /// </summary>
    public class ChatSession : BaseEntity
    {
        /// <summary>
        /// The title for this chat
        /// </summary>
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// THe timestamp for when this chat was created
        /// </summary>
        public DateTime CreatedOn { get; set; }
        
        /// <summary>
        /// The system description for the chat that is used to generate responses
        /// </summary>
        public string SystemDescription { get; set; } = string.Empty;

        /// <summary>
        /// The blance vetween long term memory and working term memory.
        /// The higher the value, the more the system will rely on long term memory.
        /// </summary>
        public float MemoryBalance { get; set; } = 0.5F;

        /// <summary>
        /// Used to update a chat or not
        /// </summary>
        public string Version { get; set; } = string.Empty;

        /// <summary>
        /// The messages that belong to this chat
        /// </summary>
        public IEnumerable<ChatMessage> Messages { get; set; } = Enumerable.Empty<ChatMessage>();
    }
}
