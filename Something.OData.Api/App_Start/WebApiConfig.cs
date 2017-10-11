using Microsoft.Owin.Security.OAuth;
using Something.OData.Api.Models;
using System.Web.Http;
using System.Web.OData.Builder;

namespace Something.OData.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
                
            );

            var modelBuilder = new ODataConventionModelBuilder();

            modelBuilder.EntitySet<TodoItem>("Todos");
            modelBuilder.EntitySet<TodoList>("TodoLists");

            config.Routes.MapODataRoute("OData", "api", modelBuilder.GetEdmModel());
        }
    }
}
