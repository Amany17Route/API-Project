using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Store.Service.Services.CachService;
using System.Text;

namespace Store.Web.Helper
{
    public class CacheAttribute : Attribute, IAsyncActionFilter
    {
        private int _timeToLiveInSeconds;


        public CacheAttribute(int timeToLiveInSeconds)
        {
            _timeToLiveInSeconds = timeToLiveInSeconds;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {

            var _cacheServices = context.HttpContext.RequestServices.GetRequiredService<ICachService>();

            var cachekey = GenerateCacheKeyFromRequest(context.HttpContext.Request);

            var cacheResponse = await _cacheServices.GetCacheResponseAsync(cachekey);

            if (!string.IsNullOrEmpty(cacheResponse))
            {
                var ContentResult = new ContentResult
                {

                    Content = cacheResponse,
                    ContentType = "application/json",
                    StatusCode = 200,
                };

                context.Result = ContentResult;
                return;

            }
            var executedContext= await next();

            if (executedContext.Result is OkObjectResult response)
            {
                await _cacheServices.SetCacheResponseAsync(cachekey, response.Value, TimeSpan.FromSeconds(_timeToLiveInSeconds));

            }


            }



        private string GenerateCacheKeyFromRequest(HttpRequest request)
        {

            StringBuilder cachekey = new StringBuilder();

            cachekey.Append($"{request.Path}");

            foreach (var (key, Value) in request.Query.OrderBy(x => x.Key))
            {
                cachekey.Append($"{key}-{Value}");
            }
            return cachekey.ToString();

        }
    }
}
