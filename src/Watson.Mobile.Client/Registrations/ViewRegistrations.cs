using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Watson.Mobile.Client.Views;

namespace Watson.Mobile.Client.Extensions
{
    public static class ViewRegistrations
    {
        public static MauiAppBuilder RegisterViews(this MauiAppBuilder builder)
        {
            builder.Services.AddTransient<MainView>();

            return builder;
        }
    }
}
