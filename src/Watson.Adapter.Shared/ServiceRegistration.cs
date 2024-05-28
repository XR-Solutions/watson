using Microsoft.Extensions.DependencyInjection;
using Watson.Adapter.Shared.Services;
using Watson.Application.Interfaces.Servcies;

namespace Watson.Adapter.Shared
{
    public static class ServiceRegistration
    {
        public static void AddSharedAdapter(this IServiceCollection services)
        {
            services.AddTransient<IDateTimeService, DateTimeService>();
        }
    }
}
