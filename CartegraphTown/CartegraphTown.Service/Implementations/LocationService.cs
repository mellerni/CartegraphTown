namespace CartegraphTown.Service.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Model;

    public class LocationService : ServiceBase
    {
        public LocationService(ICartegraphTownContext db)
        {
            this.Db = db;
        }


    }
}
