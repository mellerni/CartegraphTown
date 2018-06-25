namespace CartegraphTown.API.AutofacModule
{
    using Autofac;
    using Service.Implementations;
    using Service.Interfaces;

    public class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CitizenService>().As<ICitizenService>().InstancePerRequest();
            builder.RegisterType<IssueService>().As<IIssueService>().InstancePerRequest();
            builder.RegisterType<LocationService>().As<ILocationService>().InstancePerRequest();

            base.Load(builder);
        }
    }
}