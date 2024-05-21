using System.Web;
using System.Web.Mvc;

namespace Adyen_Payment_Gateway_Demo_MVC
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
