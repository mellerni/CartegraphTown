namespace CartegraphTown.API.Controllers
{
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using Model.DTO.Common;

    public class BaseController : ApiController
    {
        protected IHttpActionResult ProcessResult(ResultBase result)
        {
            if (!result.IsSuccess)
            {
                if (result.StatusCode != HttpStatusCode.BadRequest)
                {
                    var response = new HttpResponseMessage(result.StatusCode) { ReasonPhrase = result.Message };
                    return this.ResponseMessage(response);
                }

                return this.BadRequest(result.Message);
            }

            return this.Ok(result.Message);
        }

        /// <summary>
        /// Process Result to an IHttpActionResult
        /// </summary>
        /// <returns>Collection of booked accounts.</returns>
        protected IHttpActionResult ProcessResult<T>(Result<T> result)
        {
            if (!result.IsSuccess)
            {
                if (result.StatusCode != HttpStatusCode.BadRequest)
                {
                    var response = new HttpResponseMessage(result.StatusCode) { ReasonPhrase = result.Message };
                    return this.ResponseMessage(response);
                }

                return this.BadRequest(result.Message);
            }

            return this.Ok(result.Model);
        }
    }
}
