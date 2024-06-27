using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watson.Adapter.OpenAI.Models
{
    public class SearchResult
    {
        public string Id { get; set; }
        public string Content { get; set; }
        // Add other relevant fields from your search index
    }
}
