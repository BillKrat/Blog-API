using Framework.Shared.Extensions;
using Framework.Shared.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Security.Principal;

namespace Framework.Shared.Web.Extensions.Bootstrap
{
    /// <summary>======================================================================
    /// Namespace: Framework.Shared.Web
    ///  Filename: MiddleWareExtenions.cs
    /// Developer: Billkrat
    ///   Created: 2024.10.27
    ///   Purpose: Framework middleware for the purposed of populating the UserState
    ///            [from IPrincipal] and RequestState [from Request]
    ///            
    /// Author		Date	Comments
    /// ----------- ------- ----------------------------------------------------------
    ///  
    /// =====================================================================</summary>
    public static class MiddleWareExtensions
    {
        /// <summary>
        /// Middleware to initialize request and user state
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        public static WebApplication? UseSharedMiddleWare(this WebApplication app)
        {
            app.Use(async (context, next) =>
            {
                var services = context.RequestServices;
                var httpContext = services.Resolve<IHttpContextAccessor>()?.HttpContext;
                var principal = services.Resolve<IPrincipal>();
                var userState = services.Resolve<IUserState>();
                var requestState = services.Resolve<IRequestState>();

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
