using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace PeopleSearch
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "SearchRoute",
                routeTemplate: "api/{controller}/{searchString}",
                defaults: new { action="SearchAction", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
