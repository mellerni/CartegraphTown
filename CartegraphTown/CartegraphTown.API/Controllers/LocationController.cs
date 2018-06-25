namespace CartegraphTown.API.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Web.Http.Description;
    using System.Web.Http;
    using Model.DTO;
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
        [ResponseType(typeof(AddressDto))]
        [Route("getAllAddresses")]
        public async Task<IHttpActionResult> GetAllAddresses()
        {
            return this.ProcessResult(await this.Service.GetAllLocationsAsAddressesAsync());
        }

        [HttpGet]
        [ResponseType(typeof(PointDto))]
        [Route("getAllPoints")]
        public async Task<IHttpActionResult> GetAllPoints()
        {
            return this.ProcessResult(await this.Service.GetAllLocationsAsPointsAsync());
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
        [ResponseType(typeof(string))]
        public async Task<IHttpActionResult> Post([FromBody]AddressDto model)
        {
            return this.ProcessResult(await this.Service.CreateAsync(model));
        }

        [HttpPost]
        [ResponseType(typeof(string))]
        public async Task<IHttpActionResult> Post([FromBody]PointDto model)
        {
            return this.ProcessResult(await this.Service.CreateAsync(model));
        }

        [HttpPut]
        [ResponseType(typeof(string))]
        public async Task<IHttpActionResult> Put([FromBody]AddressDto model)
        {
            return this.ProcessResult(await this.Service.UpdateAsync(model));
        }

        [HttpPut]
        [ResponseType(typeof(string))]
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
