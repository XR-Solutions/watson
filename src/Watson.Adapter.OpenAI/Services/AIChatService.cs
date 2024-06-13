using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;
using Microsoft.SemanticKernel.Connectors.OpenAI;
using Watson.Adapter.OpenAI.Personas;
using Watson.Application.Interfaces.Services;
using Watson.Core.Entities;

namespace Watson.Adapter.OpenAI.Services
{
    public class AIChatService : IAIChatService
    {
        private readonly Kernel _kernel;
        private readonly IChatCompletionService _chat;
        private readonly OpenAIPromptExecutionSettings _executionSettings;

        public AIChatService(Kernel kernel, OpenAIPromptExecutionSettings executionSettings)
        {
            _kernel = kernel;
            _chat = kernel.GetRequiredService<IChatCompletionService>();
            _executionSettings = executionSettings;
        }

        public async Task<ChatMessage> InvokePromptAsync(ChatMessage message)
        {
            //var response = await _kernel.InvokePromptAsync(message.Content);
            throw new NotImplementedException();
        }

        // TODO: remove this one
        public async Task<string> InvokePromptAsync(string prompt)
        {
            var chatHistory = new ChatHistory(WatsonPersona.SystemMessage);
            chatHistory.AddUserMessage(prompt);

            var response = await _chat.GetChatMessageContentsAsync(chatHistory, _executionSettings, _kernel);

            var result = "";
            foreach(var message in response)
            {
                if (message.Role == AuthorRole.Assistant) result += message.Content;
            }

            return result;
        }
    }
}
