using Watson.Core.Entities;

namespace Watson.Application.Interfaces.Services
{
    public interface IAIChatService
    {
        // TODO: restore the original method and remove the base string one.
        //public Task<ChatMessage> GetResponseAsync(ChatMessage message);
        public Task<string> GetResponseAsync(string message);
    }
}
