using System.Threading.Tasks;
using Watson.Core.Entities;

namespace Watson.Application.Interfaces.Services
{
    public interface IAIChatService
    {
        // TODO: restore the original method and remove the base string one.
        //public Task<ChatMessage> InvokePromptAsync(ChatMessage message);
        public Task<string> InvokePromptAsync(string message);
    }
}
