using Microsoft.Extensions.DependencyInjection;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.Connectors.OpenAI;
using Watson.Adapter.OpenAI.Options;
using Watson.Adapter.OpenAI.Plugins;

namespace Watson.Adapter.OpenAI.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddSemanticKernelExtension(this IServiceCollection services, OpenAISettings openAISettings)
        {
            var builder = Kernel.CreateBuilder()
                .AddOpenAIChatCompletion(openAISettings.ModelType, openAISettings.ApiKey);


            OpenAIPromptExecutionSettings promptExecutionSettings = new()
            { 
                ToolCallBehavior = ToolCallBehavior.AutoInvokeKernelFunctions
            };

            services.AddSingleton(promptExecutionSettings) ;

            #region Plugins
            builder.Plugins.AddFromType<TimePlugin>();
            #endregion

            Kernel kernel = builder.Build();
            services.AddSingleton<Kernel>(kernel);
        }
    }
}
