using System.Web.Mvc;
using System.Web.Routing;

namespace WordFinderEngine.WebInterface
{
   public class RouteConfig
   {
      public static void RegisterRoutes( RouteCollection routes )
      {
         routes.IgnoreRoute( "{resource}.axd/{*pathInfo}" );

         routes.MapRoute(
             name: "Default",
             url: "{controller}/{action}/{letters}",
             defaults: new
             {
                controller = "View",
                action = "Index",
                letters = UrlParameter.Optional
             }
         );
      }
   }
}