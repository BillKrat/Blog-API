using Framework.Shared.Extensions;
using Framework.Shared.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Security.Principal;

namespace Framework.Shared.Web.Extensions.Bootstrap
{
    /// <summary>
    /// Shared Framework middleware
    /// </summary>
    public static class MiddleWareExtensions
    {
        /// <summary>
        /// Middleware to initialize request and user state
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        public static WebApplication? UseSharedMiddleWare(this WebApplication? app)
        {
            app.Use(async (context, next) =>
            {
                var httpContext = context.RequestServices.Resolve<IHttpContextAccessor>()?.HttpContext;
                var principal = context.RequestServices.Resolve<IPrincipal>();
                var userState = context.RequestServices.Resolve<IUserState>();
                var requestState = context.RequestServices.Resolve<IRequestState>();

                userState.IsAuthenticated = principal.Identity.IsAuthenticated;
                userState.Id = principal.Identity.Name;

                var request = httpContext.Request;
                requestState.BaseUrl = $"{request.Scheme}://{request.Host}";
                requestState.Controller = request.RouteValues["controller"]?.ToString();
                requestState.Path = request.Path.Value;
                requestState.Scheme = request.Scheme;
                foreach (var query in httpContext.Request.Query)
                    requestState.Parameters.Add(query.Key, query.Value);

                await next.Invoke();
            });
            return app;
        }
    }
}
