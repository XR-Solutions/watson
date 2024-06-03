using Microsoft.SemanticKernel;
using Watson.Application.Interfaces.Services;
using Watson.Core.Entities;

namespace Watson.Adapter.OpenAI.Services
{
    public class AIChatService : IAIChatService
    {
        private readonly Kernel _kernel;
        public AIChatService(Kernel kernel)
        {
            _kernel = kernel;
        }

        public async Task<ChatMessage> GetResponseAsync(ChatMessage message)
        {
            var response = await _kernel.InvokePromptAsync(message.Content);
            throw new NotImplementedException();
        }

        // TODO: remove this one
        public async Task<string> GetResponseAsync(string message)
        {
            var response = await _kernel.InvokePromptAsync(message);
            return response.ToString();
        }
    }
}
