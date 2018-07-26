using System.Web.Http;
using WebActivatorEx;
using BecaDotNet.UI.MVC.WebAPI;
using Swashbuckle.Application;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace BecaDotNet.UI.MVC.WebAPI
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                    {
                        c.SingleApiVersion("v1", "BecaDotNet.UI.MVC.WebAPI");
                    })
                .EnableSwaggerUi(c =>
                    {});
        }
    }
}
