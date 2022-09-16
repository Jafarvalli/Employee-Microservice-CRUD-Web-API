using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace EmployeeCRUDWebAPI.Middleware
{
    public class ApiKeyMiddleware
    {
        private readonly RequestDelegate _apiRequest;
        private const string APIKEY = "ApiKey";
        public ApiKeyMiddleware(RequestDelegate apiRequest)
        {
            _apiRequest = apiRequest;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            if (!context.Request.Headers.TryGetValue(APIKEY, out var Apikeyvalue))
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("API Key Was not Provided.");
                return;
            }
            var appSettings = context.RequestServices.GetRequiredService<IConfiguration>();
            var apiKey = appSettings.GetValue<string>(APIKEY);
            if (!apiKey.Equals(Apikeyvalue))
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("API Key was not Provided so,You dont have any Authorization to access this Web API.");
                return;
            }
            await _apiRequest(context);
        }
    }
}
