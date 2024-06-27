using Microsoft.Extensions.DependencyInjection;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.Connectors.OpenAI;
using Refit;
using Watson.Adapter.OpenAI.Apis;
using Watson.Adapter.OpenAI.Options;
using Watson.Adapter.OpenAI.Plugins;
using Watson.Adapter.OpenAI.Services;

namespace Watson.Adapter.OpenAI.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddSemanticKernelExtension(this IServiceCollection services, OpenAISettings openAISettings, AiSearchService searchService)
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
            builder.Plugins.AddFromObject(new KompolPlugin(searchService));
            #endregion

            Kernel kernel = builder.Build();
            services.AddSingleton<Kernel>(kernel);
        }

        public static void AddWhisperApi(this IServiceCollection services, OpenAISettings openAISettings) 
        {
            var client = new HttpClient { BaseAddress = new Uri(openAISettings.OpenAIApiUrl) };
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {openAISettings.ApiKey}");

            var audioApi = RestService.For<IAudioApi>(client);

            services.AddSingleton<IAudioApi>(audioApi);

        }
    }
}
