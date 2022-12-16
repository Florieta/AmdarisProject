
using RentACar.Api.Logger;
using RentACar.WebApi.Middleware;
using System.Net;
using System.Web.Http.Filters;

namespace RentACar.Api.CustomerFilters
{
    public class CustomApiErrorFilter : ExceptionFilterAttribute
    {
        private readonly ILog<ExceptionMiddleware> log;
        
        public CustomApiErrorFilter(ILog<ExceptionMiddleware> log)
        {
            this.log = log;

        }
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            
            log.LogExceptions(actionExecutedContext.Exception.ToString());
            var exceptionMessage = "An error occurred and logged during processing of this application.";

            var response = new HttpResponseMessage(HttpStatusCode.InternalServerError)
            {
                Content = new StringContent(exceptionMessage),
                ReasonPhrase = "Internal Server Error.Please Contact your Administrator."
            };
            actionExecutedContext.Response = response;
        }
    }
}
