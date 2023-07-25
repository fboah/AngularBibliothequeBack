using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace WebFilms
{
    public  class WebApiConfig : ApiController
    {
        [EnableCors(origins: "http://localhost:50017", headers: "*", methods: "*", SupportsCredentials = true)]
        public static void Register(HttpConfiguration config)
        {
            // Configuration et services API Web

          //  EnableCorsAttribute cors = new EnableCorsAttribute("*", "*", "*");
     

            // Itinéraires de l'API Web
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // New code
            config.EnableCors(new EnableCorsAttribute("http://localhost:50017", "*", "*"));

           
        }


      






    }
}
