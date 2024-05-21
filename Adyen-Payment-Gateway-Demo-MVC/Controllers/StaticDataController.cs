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
                new Dictionary<string, string> { { "label", "Australia" }, { "value", "AU" } },
                new Dictionary<string, string> { { "label", "Hong Kong" }, { "value", "HK" } },
                new Dictionary<string, string> { { "label", "India" }, { "value", "IN" } },
                new Dictionary<string, string> { { "label", "European Union" }, { "value", "EU" } },
                new Dictionary<string, string> { { "label", "United Kingdom" }, { "value", "UK" } },
                new Dictionary<string, string> { { "label", "United States" }, { "value", "US" } }
            };

            return Content(JsonConvert.SerializeObject(countries), "application/json");
        }
    }
}