using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watson.Core.Entities
{
    /// <summary>
    /// Information about a citation and it's source
    /// </summary>
    public class ChatCitation
    {
        /// <summary>
        /// Link of the citation
        /// </summary>
        public string Link { get; set; } = string.Empty;
        
        /// <summary>
        /// Descriptive type of resource
        /// </summary>
        public string SourceContentType { get; set; } = string.Empty;

        /// <summary>
        /// Name of the source
        /// </summary>
        public string SourceName { get; set; } = string.Empty;

        /// <summary>
        /// Highlighted snippet of the citation
        /// </summary>
        public string Snippet { get; set; } = string.Empty;

        /// <summary>
        /// Relevance score of the citation in relation to the query.
        /// </summary>
        public double RelevanceScore { get; set; } = 0.0;
    }
}
