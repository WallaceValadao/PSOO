using PSOO.WebApi.App_Start;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;

namespace PSOO.WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Formatters.Add(new ResponseFormatter());
            config.Services.Replace(typeof(IExceptionHandler), new CustomErrorHandlerAttribute()); 

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
