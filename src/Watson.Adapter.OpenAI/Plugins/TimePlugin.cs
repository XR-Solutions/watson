using Microsoft.SemanticKernel;
using System.ComponentModel;

namespace Watson.Adapter.OpenAI.Plugins
{
    public class TimePlugin
    {
        [KernelFunction]
        [Description("Retrieves the current date and time in UTC.")]
        public static string GetCurrentUtcDateTime() => DateTime.UtcNow.ToString("F");

    }
}
