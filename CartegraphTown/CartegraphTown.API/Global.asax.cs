namespace CartegraphTown.API
{
    using System.Reflection;
    using System.Web.Http;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;
    using Autofac;
    using Autofac.Integration.WebApi;
    using Serilog;

    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            const string ConnectionString = "CartegraphTownContext";

            Log.Logger = new LoggerConfiguration().WriteTo
                .MSSqlServer(ConnectionString, "ExceptionLogs").CreateLogger();

            // setup DI
            var builder = new ContainerBuilder();

            // register modules
            builder.RegisterAssemblyModules(Assembly.GetExecutingAssembly());

            // register controllers
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            // Set the dependency resolver to be Autofac.
            var container = builder.Build();
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}
