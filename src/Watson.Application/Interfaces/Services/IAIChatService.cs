using System.IO;
using System.Threading.Tasks;

namespace Watson.Application.Interfaces.Services
{
    public interface IAIChatService
    {
        // TODO: restore the original method and remove the base string one.
        //public Task<ChatMessage> InvokePromptAsync(ChatMessage message);
        public Task<string> InvokePromptAsync(string message);

        public Task<Stream> InvokeAudioPromptAsync(Stream audio, string audioName, string audioType, Stream image);
    }
}
