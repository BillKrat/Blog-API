using Framework.Shared.Extensions;
using Framework.Shared.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace Framework.Shared.Web.Extensions.Bootstrap
{
    /// <summary>======================================================================
    /// Namespace: Framework.Shared.Web
    ///  Filename: RequestMiddleWareExtensions.cs
    /// Developer: Billkrat
    ///   Created: 2024.10.27
    ///   Purpose: Framework middleware for the purposed of populating the RequestState
    ///            [from HttpContext]
    ///            
    /// Author		Date	Comments
    /// ----------- ------- ----------------------------------------------------------
    ///  
    /// =====================================================================</summary>
    public static class RequestMiddleWareExtensions
    {
        /// <summary>
        /// Middleware to initialize request 
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        public static WebApplication? UseRequestMiddleWare(this WebApplication app)
        {
            app.Use(async (context, next) =>
            {
                var services = context.RequestServices;
                var httpContext = services.Resolve<IHttpContextAccessor>()?.HttpContext;
                var requestState = services.Resolve<IRequestState>();

                var request = httpContext.Request;
                requestState.BaseUrl = $"{request.Scheme}://{request.Host}";
                requestState.Controller = request.RouteValues["controller"]?.ToString();
                requestState.Path = request.Path.Value;
                requestState.Scheme = request.Scheme;
                requestState.Host = request.Host.Host;
                requestState.Port = request.Host.Port;
                requestState.FullHost = request.Host.Value;

                foreach (var query in httpContext.Request.Query)
                {
                    requestState.Parameters.Add(query.Key, query.Value);

                    // POC concept 
                    // Example of how to redirect to a different URL.  We'll
                    // want to investigate this for request to subdomains,
                    // e.g., www.xxx.com will go to restController
                    //       schema.xxx.com will go to schemaController
                    //       api.xxx.com will go to apiController
                    //
                    // https://www.c-sharpcorner.com/article/url-rewriting-middleware-in-asp-net-core/#:~:text=The%20easiest%20way%20to%20do%20URL%20rewriting%20is,%28context%2C%20next%29%20%3D%3E%20%7B%20var%20url%20%3D%20context.
                    // The following will redirect DalSwap for DalWeatherForecast
                    // to get database list versus hardcoded list
                    //   if (query.Key == "IDal" &&
                    //      query.Value == "DalWeatherForecast")
                    //   {
                    //      httpContext.Response.Redirect($"/Rest/List");
                    //   }
                }

                await next.Invoke();
            });
            return app;
        }
    }
}
