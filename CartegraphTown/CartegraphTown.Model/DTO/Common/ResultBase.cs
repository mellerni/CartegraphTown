namespace CartegraphTown.Model.DTO.Common
{
    using System.Net;

    /// <summary>
    /// Base class for API result without type
    /// </summary>
    public class ResultBase
    {
        /// <summary>
        /// Custom constructor for ResultBase
        /// </summary>
        /// <param name="message"></param>
        /// <param name="isSuccess"></param>
        /// <param name="statusCode"></param>
        protected ResultBase(string message, bool isSuccess, HttpStatusCode statusCode)
        {
            this.Message = message;
            this.IsSuccess = isSuccess;
            this.StatusCode = statusCode;
        }

        /// <summary>
        /// Result status message
        /// </summary>
        public string Message { get; private set; }

        /// <summary>
        /// Result success flag
        /// </summary>
        public bool IsSuccess { get; private set; }

        /// <summary>
        /// Result status code
        /// </summary>
        public HttpStatusCode StatusCode { get; set; }

        /// <summary>
        /// Create successful response, status code = OK
        /// </summary>
        /// <returns></returns>
        public static ResultBase Success()
        {
            return new ResultBase("Success!", true, HttpStatusCode.OK);
        }

        /// <summary>
        /// Create successful response with custom message, status code = OK
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static ResultBase Success(string message)
        {
            return new ResultBase(message, true, HttpStatusCode.OK);
        }

        /// <summary>
        /// Create failed response, status code = BadRequest
        /// </summary>
        /// <returns></returns>
        public static ResultBase Failure()
        {
            return new ResultBase("The requested operation failed; please try again.", false, HttpStatusCode.BadRequest);
        }

        /// <summary>
        /// Create failed response with custom message, status code = BadRequest
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static ResultBase Failure(string message)
        {
            return new ResultBase(message, false, HttpStatusCode.BadRequest);
        }

        /// <summary>
        /// Create failed response with custom message and status code
        /// </summary>
        /// <param name="message"></param>
        /// <param name="statusCode"></param>
        /// <returns></returns>
        public static ResultBase Failure(string message, HttpStatusCode statusCode)
        {
            return new ResultBase(message, false, statusCode);
        }
    }
}
