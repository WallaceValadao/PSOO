using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.ExceptionHandling;
using System.Web.Http.Results;

namespace PSOO.WebApi.App_Start
{
    public class CustomErrorHandlerAttribute : ExceptionHandler
    {
        public async override Task HandleAsync(ExceptionHandlerContext context, CancellationToken cancellationToken)
        {
            var response = context.Request.CreateResponse(HttpStatusCode.InternalServerError,
            new
            {
                Message = context.Exception.Message
            });

            context.Result = new ResponseMessageResult(response);
        }
    }
}