using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Watson.Mobile.Client.Services.Navigation;

namespace Watson.Mobile.Client.Extensions
{
    public static class AppServices
    {
        public static MauiAppBuilder RegisterAppServices(this MauiAppBuilder builder)
        {
            builder.Services.AddSingleton<INavigationService, MauiNavigationService>();
            
            return builder;
        }
    }
}
