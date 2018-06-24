namespace CartegraphTown.Service.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Model;

    public class CitizenService : ServiceBase
    {
        public CitizenService(ICartegraphTownContext db)
        {
            this.Db = db;
        }

    }
}
