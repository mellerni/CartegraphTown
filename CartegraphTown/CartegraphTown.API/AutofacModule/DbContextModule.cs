namespace CartegraphTown.API.AutofacModule
{
    using Autofac;
    using Model;

    public class DbContextModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CartegraphTownContext>().As<ICartegraphTownContext>().InstancePerRequest();

            //TODO: Could add UserId Web Security when building Autofac dependency in DbContextModule

            base.Load(builder);
        }
    }
}