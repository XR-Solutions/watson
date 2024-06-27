using Microsoft.Extensions.Configuration;
using Watson.Mobile.Client.Options;

namespace Watson.Mobile.Client.Registrations
{
    public static class OptionRegistrations
    {
        public static MauiAppBuilder RegisterOptions(this MauiAppBuilder builder, IConfiguration configuration)
        {
            builder.Services.AddOptions<LinkSettings>().BindConfiguration(nameof(LinkSettings))
                .ValidateDataAnnotations().ValidateOnStart();

            builder.Services.AddOptions<ApiSettings>().BindConfiguration(nameof(ApiSettings));

            return builder;
        }
    }
}
