namespace CartegraphTown.API.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Web.Http.Description;
    using System.Web.Http;
    using Model.DTO;
    using Service.Interfaces;

    [RoutePrefix("api/issue")]
    public class IssueController : BaseController
    {
        public IssueController(IIssueService service)
        {
            this.Service = service;
        }

        private IIssueService Service { get; set; }

        [HttpGet]
        [ResponseType(typeof(IssueDto))]
        [Route("getAll")]
        public async Task<IHttpActionResult> GetAll()
        {
            return this.ProcessResult(await this.Service.GetAllIssuesAsync());
        }

        [HttpGet]
        [ResponseType(typeof(IssueDto))]
        [Route("get/{issueId:int}")]
        public async Task<IHttpActionResult> Get(int issueId)
        {
            return this.ProcessResult(await this.Service.GetIssueAsync(issueId));
        }

        [HttpPost]
        [ResponseType(typeof(string))]
        public async Task<IHttpActionResult> Post([FromBody]IssueDto model)
        {
            return this.ProcessResult(await this.Service.CreateAsync(model));
        }

        [HttpPut]
        [ResponseType(typeof(string))]
        public async Task<IHttpActionResult> Put([FromBody]IssueDto model)
        {
            return this.ProcessResult(await this.Service.UpdateAsync(model));
        }

        [HttpDelete]
        [ResponseType(typeof(string))]
        public async Task<IHttpActionResult> Delete(int issueId)
        {
            return this.ProcessResult(await this.Service.DeleteAsync(issueId));
        }
    }
}
