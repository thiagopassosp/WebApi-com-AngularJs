using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace GDI {
    public static class WebApiConfig {
        public static void Register(HttpConfiguration config) {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            //Converter as requisições em JSON
            var json = config.Formatters.JsonFormatter;
            json.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.Objects;
            config.Formatters.Remove(config.Formatters.XmlFormatter);


            config.Routes.MapHttpRoute(
                name: "ActionApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
          //  config.Routes.MapHttpRoute(
          //    name: "DefaultApi",
          //    routeTemplate: "api/{controller}/{Action}/{id}",
          //    defaults: new { id = RouteParameter.Optional }
          //);
        }
    }
}
