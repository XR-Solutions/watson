using Microsoft.Extensions.DependencyInjection;
using Microsoft.SemanticKernel;
using Watson.Adapter.OpenAI.Options;

namespace Watson.Adapter.OpenAI.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddSemanticKernelExtension(this IServiceCollection services, OpenAISettings openAISettings)
        {
            var builder = Kernel.CreateBuilder()
                .AddOpenAIChatCompletion(openAISettings.ModelType, openAISettings.ApiKey);

            #region Plugins

            #endregion

            Kernel kernel = builder.Build();
            services.AddSingleton<Kernel>(kernel);
        }
    }
}
