using Store.Service.Handle_Response;
using System.Net;
using System.Text.Json;

namespace Store.Web.MiddleWare
{
    public class ExeptionMiddleWare
    {
        private readonly RequestDelegate next;
        private readonly ILogger<ExeptionMiddleWare> logger;
        private readonly IHostEnvironment env;


        public ExeptionMiddleWare(RequestDelegate Next, ILogger<ExeptionMiddleWare> logger, IHostEnvironment env)
        {
            next = Next;
            this.logger = logger;
            this.env = env;
        }


        public async Task InvokeAsync(HttpContext context)
        {

            try
            {
                await next.Invoke(context);
            }
            catch (Exception ex)
            {

                logger.LogError(ex, ex.Message);
                context.Response.ContentType = "applicatin/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                var ResponseEnv = env.IsDevelopment() ? new CustomeExeption(500, ex.Message, ex.StackTrace.ToString())
                : new CustomeExeption((int)HttpStatusCode.InternalServerError);

                var Options = new JsonSerializerOptions()
                {

                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                };
                var jsonResponce = JsonSerializer.Serialize(ResponseEnv, Options);
                await context.Response.WriteAsync(jsonResponce);
            }
        }
    }
}
