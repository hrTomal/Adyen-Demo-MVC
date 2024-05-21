using System.Web.Http;
using WebActivatorEx;
using Adyen_Payment_Gateway_Demo_MVC;
using Swashbuckle.Application;
using System.IO;
using System.Reflection;
using System;
using System.Diagnostics;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace Adyen_Payment_Gateway_Demo_MVC
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                    {
                        c.SingleApiVersion("v1", "Adyen_Payment_Gateway_Demo_MVC");

                        var xmlPath = GetXmlCommentsPath();
                        if (!string.IsNullOrEmpty(xmlPath))
                        {
                            Debug.WriteLine($"Including XML comments from: {xmlPath}");
                            c.IncludeXmlComments(xmlPath);
                        }
                        else
                        {
                            Debug.WriteLine("No XML comments found.");
                        }
                    })
                .EnableSwaggerUi(c =>
                    {
                    });
        }

        private static string GetXmlCommentsPath()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var basePath = AppDomain.CurrentDomain.BaseDirectory + "bin";
            var xmlName = assembly.GetName().Name + ".xml";
            var xmlPath = Path.Combine(basePath, xmlName);
            return File.Exists(xmlPath) ? xmlPath : "";
        }
    }
}
