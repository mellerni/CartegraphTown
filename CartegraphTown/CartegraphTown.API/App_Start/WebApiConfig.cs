namespace CartegraphTown.API
{
    using System.Web.Http;
    using System.Configuration;
    using System.Web.Http.Cors;
    using Filters;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;

    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Enable Cors
            var origin = ConfigurationManager.AppSettings["WebAppUrl"].TrimEnd('/');
            var cors = new EnableCorsAttribute(origin, "*", "*", "FileName, FileType");
            config.EnableCors(cors);

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            var formatters = config.Formatters;

            // removes XML support from the API
            formatters.XmlFormatter.SupportedMediaTypes.Clear();

            // setup JSON formatter
            var jsonSettings = formatters.JsonFormatter.SerializerSettings;

            // indents JSON output
            jsonSettings.Formatting = Formatting.Indented;

            //return DateTime in UTC
            jsonSettings.DateTimeZoneHandling = DateTimeZoneHandling.Utc;

            // convert PascalCase to camelJson during serialization
            jsonSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            // logs out unhandled exceptions
            config.Filters.Add(new ExceptionHandlingAttribute());
        }
    }
}
