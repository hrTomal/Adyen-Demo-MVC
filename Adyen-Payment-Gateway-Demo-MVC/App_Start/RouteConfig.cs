using System.Web.Mvc;
using System.Web.Routing;

namespace Adyen_Payment_Gateway_Demo_MVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            
            routes.MapRoute(
                name: "StandardWebhookNotifications",
                url: "standardwebhook/notifications",
                defaults: new { controller = "StandardWebhook", action = "Webhooks" }
            );
            
            routes.MapRoute(
                name: "SubscriptionWebhookNotifications",
                url: "subscriptionwebhook/notifications",
                defaults: new { controller = "SubscriptionWebhook", action = "Webhooks" }
            );
            
            routes.MapRoute(
                name: "BalancePlatformWebhookNotifications",
                url: "balanceplatformwebhook/notifications",
                defaults: new { controller = "BalancePlatformWebhook", action = "Webhooks" }
            );
            
            //routes.MapRoute(
            //    name: "CheckoutWebhookNotifications",
            //    url: "checkoutwebhook/notifications",
            //    defaults: new { controller = "CheckoutWebhook", action = "Webhooks" }
            //);

            // Route for API endpoints
            routes.MapRoute(
                name: "Api",
                url: "api/{controller}/{action}/{id}",
                defaults: new { id = UrlParameter.Optional }
            );
        }

    }
}
