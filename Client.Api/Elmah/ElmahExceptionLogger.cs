using System.Web;
using System.Web.Http.ExceptionHandling;
using Elmah;

namespace Client.Api.Elmah
{
    public class ElmahExceptionLogger : ExceptionLogger
    {
        public override void Log(ExceptionLoggerContext context)
        {
            var signal = ErrorSignal.FromCurrentContext();

            signal?.Raise(context.Exception, HttpContext.Current);
        }
    }
}