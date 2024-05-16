using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc;
using Watson.Web.Conventions;

namespace Watson.Web.Extensions
{
    public static class MvcOptionsExtension
    {
        public static void UseGeneralRoutePrefix(this MvcOptions options, IRouteTemplateProvider routeAttributes)
        {
            options.Conventions.Add(new RoutePrefixConvention(routeAttributes));
        }

        public static void UseGeneralRoutePrefix(this MvcOptions options, string prefix)
        {
            options.UseGeneralRoutePrefix(new RouteAttribute(prefix));
        }
    }
}
