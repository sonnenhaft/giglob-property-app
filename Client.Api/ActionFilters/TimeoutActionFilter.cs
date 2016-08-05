using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Filters;

namespace Client.Api.ActionFilters
{
    public class TimeoutActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            base.OnActionExecuted(actionExecutedContext);

            if (actionExecutedContext.Exception != null && actionExecutedContext.Exception.GetType() == typeof (TimeoutException))
            {
                actionExecutedContext.Response = actionExecutedContext.Request.CreateResponse(HttpStatusCode.RequestTimeout, actionExecutedContext.Exception.Message);
            }
        }

        public override Task OnActionExecutedAsync(HttpActionExecutedContext actionExecutedContext, CancellationToken cancellationToken)
        {
            return Task.Run(
                () =>
                {
                    base.OnActionExecutedAsync(actionExecutedContext, cancellationToken);

                    if (actionExecutedContext.Exception != null && actionExecutedContext.Exception.GetType() == typeof (TimeoutException))
                    {
                        actionExecutedContext.Response = actionExecutedContext.Request.CreateResponse(HttpStatusCode.RequestTimeout, actionExecutedContext.Exception.Message);
                    }
                },
                cancellationToken);
        }
    }
}