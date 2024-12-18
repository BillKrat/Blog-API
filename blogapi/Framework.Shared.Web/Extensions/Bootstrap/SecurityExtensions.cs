using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Security.Principal;

namespace Framework.Shared.Web.Extensions.Bootstrap
{
    /// <summary>======================================================================
    /// Namespace: Framework.Shared.Web
    ///  Filename: SecurityExtensions.cs
    /// Developer: Billkrat
    ///   Created: 2024.10.27
    ///   Purpose: Provide access to IPrincipal and Auth0
    ///
    /// Author		Date	Comments
    /// ----------- ------- ----------------------------------------------------------
    ///  
    /// =====================================================================</summary>
    public static class SecurityExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static WebApplicationBuilder ConfigureSecurity(this WebApplicationBuilder builder)
        {
            var configuration = builder.Configuration;
            var services = builder.Services;

            services.AddHttpContextAccessor(); // Required for IHttpContextAccessor
            services.AddTransient<IPrincipal>(provider =>
                provider.GetService<IHttpContextAccessor>().HttpContext.User);

            var domain = configuration["Auth0:Domain"];
            var audience = configuration["Auth0:Audience"];

            services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.Authority = $"https://{domain}";
                    options.Audience = audience;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        NameClaimType = ClaimTypes.NameIdentifier
                    };
                });

            return builder;
        }


    }
}