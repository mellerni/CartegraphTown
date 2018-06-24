namespace CartegraphTown.Service.Implementations
{
    using Model;

    public class ServiceBase
    {
        public ServiceBase()
        {
            this.Db = new CartegraphTownContext();
        }

        protected ICartegraphTownContext Db { get; set; }
    }
}
