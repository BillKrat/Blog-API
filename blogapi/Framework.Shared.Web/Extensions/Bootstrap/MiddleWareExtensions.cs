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
        /// 
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        public static WebApplication? UseSharedMiddleWare(this WebApplication? app)
        {
            app.Use(async (context, next) =>
            {
                var httpContext = context.RequestServices.Resolve<IHttpContextAccessor>()?.HttpContext;
                var request = httpContext.Request;
                var principal = context.RequestServices.Resolve<IPrincipal>();
                var userState = context.RequestServices.Resolve<IUserState>();
                var requestState = context.RequestServices.Resolve<IRequestState>();

                userState.IsAuthenticated = principal.Identity.IsAuthenticated;
                userState.Id = principal.Identity.Name;

                requestState.BaseUrl = $"{request.Scheme}://{request.Host}";
                foreach (var query in httpContext.Request.Query)
                    requestState.Parameters.Add(query.Key, query.Value);


                await next.Invoke();
            });


            return app;
        }
    }
}
