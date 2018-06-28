namespace CartegraphTown.API.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Web.Http.Description;
    using System.Web.Http;
    using Model.DTO;
    using Model.DTO.Common;
    using Service.Interfaces;

    [RoutePrefix("api/citizen")]
    public class CitizenController : BaseController
    {
        public CitizenController(ICitizenService service)
        {
            this.Service = service;
        }

        private ICitizenService Service { get; set; }

        [HttpGet]
        [ResponseType(typeof(IEnumerable<TypeAheadDto>))]
        [Route("getTypeAhead")]
        public async Task<IHttpActionResult> GetTypeAhead()
        {
            return this.ProcessResult(await this.Service.GetCitizenTypeAheadAsync());
        }

        [HttpGet]
        [ResponseType(typeof(CitizenDto))]
        [Route("getAll")]
        public async Task<IHttpActionResult> GetAll()
        {
            return this.ProcessResult(await this.Service.GetAllCitizensAsync());
        }

        [HttpGet]
        [ResponseType(typeof(CitizenDto))]
        [Route("get/{citizenId:int}")]
        public async Task<IHttpActionResult> Get(int citizenId)
        {
            return this.ProcessResult(await this.Service.GetCitizenAsync(citizenId));
        }

        [HttpPost]
        [ResponseType(typeof(string))]
        public async Task<IHttpActionResult> Post([FromBody]CitizenDto model)
        {
            return this.ProcessResult(await this.Service.CreateAsync(model));
        }

        [HttpPut]
        [ResponseType(typeof(string))]
        public async Task<IHttpActionResult> Put([FromBody]CitizenDto model)
        {
            return this.ProcessResult(await this.Service.UpdateAsync(model));
        }

        [HttpDelete]
        [ResponseType(typeof(string))]
        public async Task<IHttpActionResult> Delete(int citizenId)
        {
            return this.ProcessResult(await this.Service.DeleteAsync(citizenId));
        }
    }
}
