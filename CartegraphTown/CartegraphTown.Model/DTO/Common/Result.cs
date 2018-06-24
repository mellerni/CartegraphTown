namespace CartegraphTown.Model.DTO.Common
{
    using System.Net;

    /// <summary>
    /// Generic API result with message and status code of type T
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Result<T> : ResultBase
    {
        /// <summary>
        /// Custom constructor for Result 
        /// </summary>
        /// <param name="isSuccess"></param>
        /// <param name="message"></param>
        /// <param name="statusCode"></param>
        /// <param name="model"></param>
        private Result(bool isSuccess, string message, HttpStatusCode statusCode, T model)
            : base(message, isSuccess, statusCode)
        {
            this.Model = model;
        }

        /// <summary>
        /// Generic model object 
        /// </summary>
        public T Model { get; private set; }

        /// <summary>
        /// Create successful response with generic object, status code = OK
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static Result<T> Success(T model)
        {
            return new Result<T>(true, "Success!", HttpStatusCode.OK, model);
        }

        /// <summary>
        /// Create successful response with generic object and custom message, status code = OK
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static Result<T> Success(string message, T model)
        {
            return new Result<T>(true, message, HttpStatusCode.OK, model);
        }

        /// <summary>
        /// Create failed response with generic object, status code = BadRequest
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static Result<T> Failure(T model)
        {
            return new Result<T>(
                false,
                "The requested operation failed; please try again.",
                HttpStatusCode.BadRequest,
                model);
        }

        /// <summary>
        /// Create failed response with generic object and custom message, status code = BadRequest
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static Result<T> Failure(string message, T model = default(T))
        {
            return new Result<T>(false, message, HttpStatusCode.BadRequest, model);
        }

        /// <summary>
        /// Create failed response with generic object, custom message, and custom status code
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static Result<T> Failure(string message, HttpStatusCode statusCode, T model)
        {
            return new Result<T>(false, message, statusCode, model);
        }
    }
}
