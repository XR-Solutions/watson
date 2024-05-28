using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watson.Core.Enums
{
    /// <summary>
    /// Type of message
    /// </summary>
    public enum ChatMessageType
    {
        /// <summary>
        /// Default text message
        /// </summary>
        Message,

        /// <summary>
        /// A message for a plan
        /// </summary>
        Plan,

        /// <summary>
        /// A document notify message
        /// </summary>
        Document,
    }
}
