using System.Security.Claims;
using System.Security.Principal;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace blogapi.Extensions{
    public static class SecurityExtensions
    {
        public static WebApplicationBuilder ConfigureSecurity(this WebApplicationBuilder builder){
            var configuration = builder.Configuration;

            var services = builder.Services;
            var domain = configuration["Auth0:Domain"];
            var audience = configuration["Auth0:Audience"];

            services.AddHttpContextAccessor(); // Required for IHttpContextAccessor

            services.AddTransient<IPrincipal>(
                provider => provider.GetService<IHttpContextAccessor>().HttpContext.User);

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