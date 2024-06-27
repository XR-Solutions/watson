using Azure;
using Azure.Search.Documents;
using Azure.Search.Documents.Models;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Watson.Adapter.OpenAI.Models;
using Watson.Adapter.OpenAI.Options;

namespace Watson.Adapter.OpenAI.Services
{
    public class AiSearchService
    {
        private readonly SearchClient _searchClient;

        public AiSearchService(AzureAiSearchSettings aiSearchSettings)
        {
            var endpoint = new Uri($"https://{aiSearchSettings.ServiceName}.search.windows.net");
            var credential = new AzureKeyCredential(aiSearchSettings.ApiKey);
            _searchClient = new SearchClient(endpoint, aiSearchSettings.IndexName, credential);
        }

        public async Task<IReadOnlyList<SearchResult>> SearchAsync(string query)
        {
            var searchOptions = new SearchOptions
            {
                IncludeTotalCount = true,
                QueryType = SearchQueryType.Simple,
                Size = 10,
            };

            var searchResult = await _searchClient.SearchAsync<SearchDocument>(query, searchOptions);
            var results = new List<SearchResult>();

            await foreach (var result in searchResult.Value.GetResultsAsync())
            {
                var newResult = new SearchResult
                {
                    Content = result.Document.FirstOrDefault().Value.ToString()
                };
                results.Add(newResult);
            }

            return results;

        }
    }
}
