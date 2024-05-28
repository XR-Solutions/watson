using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watson.Core.Enums
{
    /// <summary>
    /// Role of the chat message author
    /// </summary>
    public enum ChatAuthorRole
    {
        /// <summary>
        /// The current user of the chat
        /// </summary>
        User = 0,

        /// <summary>
        /// The chat bot
        /// </summary>
        Bot,

        /// <summary>
        /// A participant who is both not the bot and current user
        /// </summary>
        Participant,
    }
}
