using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Web.Mvc;
using Adyen.Model.Checkout;
using Adyen_Payment_Gateway_Demo_MVC.Application.Features.AdyenPayments.AdyenLibrary;
using Newtonsoft.Json;

namespace Adyen_Payment_Gateway_Demo_MVC.Controllers
{
    [RoutePrefix("api/static")]
    public class StaticDataController : Controller
    {

        [HttpGet]
        [Route("countries")]
        public async Task<ActionResult> Countries()
        {
            var countries = new List<Dictionary<string, string>>
            {
                new Dictionary<string, string> { { "label", "Australia" }, { "value", "AU" }, { "currency", "AUD" }},
                new Dictionary<string, string> { { "label", "Netherland" }, { "value", "NL" }, { "currency", "EUR" } },
                new Dictionary<string, string> { { "label", "United States" }, { "value", "US" }, { "currency", "USD" } },
                new Dictionary<string, string> { { "label", "United Kingdom" }, { "value", "GB" }, { "currency", "GBP" } },
                new Dictionary<string, string> { { "label", "Ireland" }, { "value", "IE" }, { "currency", "EUR" } },
            };

            return Content(JsonConvert.SerializeObject(countries), "application/json");
        }
    }
}