using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;
using Microsoft.SemanticKernel.Connectors.OpenAI;
using System.Text;
using Watson.Adapter.OpenAI.Apis;
using Watson.Adapter.OpenAI.Personas;
using Watson.Application.Interfaces.Services;
using Watson.Core.Entities;
using Microsoft.AspNetCore.StaticFiles;

namespace Watson.Adapter.OpenAI.Services
{
    public class AIChatService : IAIChatService
    {
        private readonly Kernel _kernel;
        private readonly IChatCompletionService _chat;
        private readonly OpenAIPromptExecutionSettings _executionSettings;
        private readonly IWhisperApi _whipserApi;
        private readonly FileExtensionContentTypeProvider typeProvider = new();

        // TODO: this should not be kept in memory like this
        private readonly ChatHistory _chatHistory = new(WatsonPersona.SystemMessage);

        public AIChatService(Kernel kernel, OpenAIPromptExecutionSettings executionSettings, IWhisperApi whisperApi)
        {
            _kernel = kernel;
            _chat = kernel.GetRequiredService<IChatCompletionService>();
            _executionSettings = executionSettings;
            _whipserApi = whisperApi;
        }

        public async Task<ChatMessage> InvokePromptAsync(ChatMessage message)
        {
            //var response = await _kernel.InvokePromptAsync(message.Content);
            throw new NotImplementedException();
        }

        // TODO: remove this one
        public async Task<string> InvokePromptAsync(string prompt)
        {
            _chatHistory.AddUserMessage(prompt);

            var response = await _chat.GetChatMessageContentsAsync(_chatHistory, _executionSettings, _kernel);
            return ProcessResponseAsync(response);
        }

        // TODO: this sucks, remove this
        public async Task<string> InvokeAudioPromptAsync(Stream audio, string audioName, string audioType, Stream image)
        {
            var whisperResponse = await _whipserApi.TranscribeAudio(new Refit.StreamPart(audio, audioName));

            var message = new ChatMessageContentItemCollection
            {
                new TextContent(whisperResponse.Text)
            };
            // new ImageContent(new ReadOnlyMemory<byte>(image))

            _chatHistory.AddUserMessage(message);

            var response = await _chat.GetChatMessageContentsAsync(_chatHistory);
            return ProcessResponseAsync(response);
        }
        private string ProcessResponseAsync(IReadOnlyList<ChatMessageContent> response)
        {
            StringBuilder builder = new();
            foreach (var message in response)
            {
                if (message.Role == AuthorRole.Assistant) builder.Append(message.Content);
            }

            _chatHistory.AddAssistantMessage(builder.ToString());
            return builder.ToString();
        }
    }
}
