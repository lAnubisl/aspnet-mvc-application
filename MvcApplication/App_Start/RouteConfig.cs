using System.Globalization;
using System.Web.Mvc;
using System.Web.Routing;

namespace MvcApplication.App_Start
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes, string[] ignoreExtentions)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("{*favicon}", new { favicon = @"(.*/)?favicon.ico(/.*)?" });
            routes.IgnoreRoute("{*resource}", new { resource = string.Format(CultureInfo.InvariantCulture, @".*\.({0})(/.*)?", string.Join("|", ignoreExtentions)) });

            routes.MapRoute("Home", "{action}", new { controller = "Home", action = "Index" });
            routes.MapRoute("CategorySeoURL", "Category/{seoURL}", new { controller = "Category", action = "Index", seoUrl = string.Empty });
            routes.MapRoute("Default", "{controller}/{action}/{id}", new { controller = "Home", action = "Index", id = UrlParameter.Optional });

            ////This route supports links to static html pages ex.: http://www.domain.com/Traider/test/mypage.html
            ////routes.MapRoute("TraderStaticPage","Trader/{*page}", new { controller = "TraderStatic", action = "Redirect" }, new { page = @"[\w%/]+.html$" });
        }
    }
}