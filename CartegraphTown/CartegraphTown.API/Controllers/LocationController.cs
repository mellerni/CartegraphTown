namespace CartegraphTown.API.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Web.Http.Description;
    using System.Web.Http;
    using Model.DTO;
    using Model.DTO.Common;
    using Service.Interfaces;

    [RoutePrefix("api/location")]
    public class LocationController : BaseController
    {
        public LocationController(ILocationService service)
        {
            this.Service = service;
        }

        private ILocationService Service { get; set; }

        [HttpGet]
        [ResponseType(typeof(IEnumerable<TypeAheadDto>))]
        [Route("getTypeAhead")]
        public async Task<IHttpActionResult> GetTypeAhead()
        {
            return this.ProcessResult(await this.Service.GetLocationTypeAheadAsync());
        }

        [HttpGet]
        [ResponseType(typeof(IEnumerable<AddressDto>))]
        [Route("getAllAddresses")]
        public async Task<IHttpActionResult> GetAllAddresses()
        {
            return this.ProcessResult(await this.Service.GetAllLocationsAsAddressesAsync());
        }

        [HttpGet]
        [ResponseType(typeof(IEnumerable<PointDto>))]
        [Route("getAllPoints")]
        public async Task<IHttpActionResult> GetAllPoints()
        {
            return this.ProcessResult(await this.Service.GetAllLocationsAsPointsAsync());
        }

        [HttpGet]
        [ResponseType(typeof(IEnumerable<StateDto>))]
        [Route("getStates")]
        public async Task<IHttpActionResult> GetStates()
        {
            return this.ProcessResult(await this.Service.GetStates());
        }

        [HttpGet]
        [ResponseType(typeof(AddressDto))]
        [Route("getAddress/{locationId:int}")]
        public async Task<IHttpActionResult> GetAddress(int locationId)
        {
            return this.ProcessResult(await this.Service.GetLocationAsAddressAsync(locationId));
        }

        [HttpGet]
        [ResponseType(typeof(PointDto))]
        [Route("getPoint/{locationId:int}")]
        public async Task<IHttpActionResult> GetPoint(int locationId)
        {
            return this.ProcessResult(await this.Service.GetLocationAsPointAsync(locationId));
        }

        [HttpPost]
        [ResponseType(typeof(int))]
        [Route("postAddress")]
        public async Task<IHttpActionResult> Post([FromBody]AddressDto model)
        {
            return this.ProcessResult(await this.Service.CreateAsync(model));
        }

        [HttpPost]
        [ResponseType(typeof(int))]
        [Route("postPoint")]
        public async Task<IHttpActionResult> Post([FromBody]PointDto model)
        {
            return this.ProcessResult(await this.Service.CreateAsync(model));
        }

        [HttpPut]
        [ResponseType(typeof(string))]
        [Route("putAddress")]
        public async Task<IHttpActionResult> Put([FromBody]AddressDto model)
        {
            return this.ProcessResult(await this.Service.UpdateAsync(model));
        }

        [HttpPut]
        [ResponseType(typeof(string))]
        [Route("putPoint")]
        public async Task<IHttpActionResult> Put([FromBody]PointDto model)
        {
            return this.ProcessResult(await this.Service.UpdateAsync(model));
        }

        [HttpDelete]
        [ResponseType(typeof(string))]
        public async Task<IHttpActionResult> Delete(int locationId)
        {
            return this.ProcessResult(await this.Service.DeleteAsync(locationId));
        }
    }
}
