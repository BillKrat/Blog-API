using Framework.Shared.Extensions;
using Framework.Shared.Interfaces;
using Microsoft.AspNetCore.Builder;
using System.Security.Principal;

namespace Framework.Shared.Web.Extensions.Bootstrap
{
    /// <summary>======================================================================
    /// Namespace: Framework.Shared.Web
    ///  Filename: UserMiddleWareExtenions.cs
    /// Developer: Billkrat
    ///   Created: 2024.10.27
    ///   Purpose: Framework middleware for the purposed of populating the UserState
    ///            [from IPrincipal] 
    ///            
    /// Author		Date	Comments
    /// ----------- ------- ----------------------------------------------------------
    ///  
    /// =====================================================================</summary>
    public static class UserMiddleWareExtensions
    {
        /// <summary>
        /// Middleware to initialize user state
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        public static WebApplication? UseUserMiddleWare(this WebApplication app)
        {
            app.Use(async (context, next) =>
            {
                var services = context.RequestServices;
                var principal = services.Resolve<IPrincipal>();
                var userState = services.Resolve<IUserState>();

                userState.IsAuthenticated = principal.Identity.IsAuthenticated;
                userState.Id = principal.Identity.Name;

                await next.Invoke();
            });
            return app;
        }
    }
}
