using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Filters;
using Domain.Exceptions;

namespace Client.Api.ActionFilters
{
    public class NotFoundActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            base.OnActionExecuted(actionExecutedContext);

            if (actionExecutedContext.Exception != null && actionExecutedContext.Exception.GetType() == typeof (NotFoundException))
            {
                actionExecutedContext.Response = actionExecutedContext.Request.CreateResponse(HttpStatusCode.NotFound, actionExecutedContext.Exception.Message);
            }
        }

        public override Task OnActionExecutedAsync(HttpActionExecutedContext actionExecutedContext, CancellationToken cancellationToken)
        {
            return Task.Run(
                () =>
                {
                    base.OnActionExecutedAsync(actionExecutedContext, cancellationToken);

                    if (actionExecutedContext.Exception != null && actionExecutedContext.Exception.GetType() == typeof (NotFoundException))
                    {
                        actionExecutedContext.Response = actionExecutedContext.Request.CreateResponse(HttpStatusCode.RequestTimeout, actionExecutedContext.Exception.Message);
                    }
                },
                cancellationToken);
        }
    }
}