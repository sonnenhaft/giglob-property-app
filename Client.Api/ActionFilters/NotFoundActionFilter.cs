using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;
using Domain.Exceptions;

namespace Client.Api.ActionFilters
{
    public class NotFoundActionFilter: ActionFilterAttribute
    {
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            base.OnActionExecuted(actionExecutedContext);

            if (actionExecutedContext.Exception != null && actionExecutedContext.Exception.GetType() == typeof (NotFoundException))
            {
                actionExecutedContext.Response = actionExecutedContext.Request.CreateResponse(HttpStatusCode.NotFound, actionExecutedContext.Exception.Message);
            }
        }
    }
}