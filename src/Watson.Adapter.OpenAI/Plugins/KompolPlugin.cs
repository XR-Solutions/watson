using Microsoft.SemanticKernel;
using System.ComponentModel;
using Watson.Adapter.OpenAI.Models;
using Watson.Adapter.OpenAI.Services;

namespace Watson.Adapter.OpenAI.Plugins
{
    public class KompolPlugin
    {
        private readonly AiSearchService _aiSearchService;

        public KompolPlugin(AiSearchService aiSearchService)
        {
            _aiSearchService = aiSearchService;
        }

        [KernelFunction]
        [Description("Queries official documents from KOMPOL, around crime scene investigation, " +
            "procedures that have to be taken and more")]
        public async Task<string> InvokeSemanticSearch(
                [Description("The search query to get the most relevant documents")] string query
            )
        {
            var response = await _aiSearchService.SearchAsync(query);
            return ProcessSearchResults(response);
        }

        private string ProcessSearchResults(IReadOnlyList<SearchResult> searchResults)
        {
            // Strip the contents of the top search results only
            var relevantContent = string.Join("\n\n", searchResults.Select(r => r.Content));
            return relevantContent;
        }
    }
}
