using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace PeopleSearch
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            RouteTable.Routes.Ignore("api*");
            RouteTable.Routes.MapPageRoute("AngularRoute", "{*route}", "~/UI/build/index.html");
            RouteTable.Routes.MapPageRoute("AngularRouteWithParam", "*/{route}/{id}", "~/UI/build/index.html");

            AutoMapperConfiguration.Configure();
        }
    }
}
