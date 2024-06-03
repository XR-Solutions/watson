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

            var openAiSettings = new OpenAISettings();
            configuration.Bind(nameof(openAiSettings), openAiSettings);

            services.AddSemanticKernelExtension(openAiSettings);

            #region Services
            services.AddScoped<IAIChatService, AIChatService>();
            #endregion
        }
    }
}
