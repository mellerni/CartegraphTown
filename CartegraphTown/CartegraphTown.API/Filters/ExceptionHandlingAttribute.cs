namespace CartegraphTown.API.Filters
{
    using System.Web.Http.Filters;
    using Serilog;

    public class ExceptionHandlingAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext filterContext)
        {
            while (filterContext.Exception.InnerException != null)
            {
                filterContext.Exception = filterContext.Exception.InnerException;
            }

            Log.Logger.Error(filterContext.Exception, filterContext.Exception.Message);
        }
    }

}