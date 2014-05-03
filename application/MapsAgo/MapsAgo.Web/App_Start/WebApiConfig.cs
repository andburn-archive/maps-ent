using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace MapsAgo.Web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            config.EnableCors(); // requires Install-Package Microsoft.AspNet.WebApi.Cors -pre -project WebService

            // Web API routes
            config.MapHttpAttributeRoutes();


            config.Routes.MapHttpRoute(
               name: "APIEvents",
               routeTemplate: "api/{zoom}/{lat}/{lon}",
               defaults: new
               {
                   controller = "APIEvents",
                   catagories = RouteParameter.Optional,
                   startdate = RouteParameter.Optional,
                   enddate = RouteParameter.Optional,
                   keywords = RouteParameter.Optional
               }
           );


            config.Routes.MapHttpRoute(
                name: "AllEvents",
                routeTemplate: "api/events",
                defaults: new
                {
                    controller = "APIEvents",
                    id = RouteParameter.Optional
                }
            );
        }
    }
}
