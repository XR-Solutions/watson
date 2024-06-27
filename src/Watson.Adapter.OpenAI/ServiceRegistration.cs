using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Watson.Adapter.OpenAI.Options;
using Watson.Adapter.OpenAI.Extensions;
using Watson.Application.Interfaces.Services;
using Watson.Adapter.OpenAI.Services;

namespace Watson.Adapter.OpenAI
{
    public static class ServiceRegistration
    {
        public static void AddOpenAIAdapter(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddOptions<OpenAISettings>().BindConfiguration(nameof(OpenAISettings))
                .ValidateDataAnnotations().ValidateOnStart();

            services.AddOptions<AzureAiSearchSettings>().BindConfiguration(nameof(AzureAiSearchSettings));

            var openAiSettings = new OpenAISettings();
            configuration.Bind(nameof(openAiSettings), openAiSettings);

            var azureAiSearchSettings = new AzureAiSearchSettings();
            configuration.Bind(nameof(azureAiSearchSettings), azureAiSearchSettings);

            AiSearchService searchService = new(azureAiSearchSettings);

            services.AddSemanticKernelExtension(openAiSettings, searchService);
            services.AddWhisperApi(openAiSettings);

            #region Services
            // TODO: This should be scoped, but for demonstration purposes we will keep everything in memory via a singleton.
            services.AddSingleton<IAIChatService, AIChatService>();
            services.AddSingleton(searchService);
            #endregion
        }
    }
}
