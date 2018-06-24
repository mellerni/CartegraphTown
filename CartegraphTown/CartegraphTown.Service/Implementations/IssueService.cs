namespace CartegraphTown.Service.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Model;

    public class IssueService : ServiceBase
    {
        public IssueService(ICartegraphTownContext db)
        {
            this.Db = db;
        }

    }
}
