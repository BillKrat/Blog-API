using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace Framework.Shared.Web.Extensions.Bootstrap
{
    /// <summary>======================================================================
    /// Namespace: Framework.Shared.Web
    ///  Filename: SwaggerExtensions.cs
    /// Developer: Billkrat
    ///   Created: 2024.10.27
    ///   Purpose: Configure swagger 
    ///
    /// Author		Date	Comments
    /// ----------- ------- ----------------------------------------------------------
    ///  
    /// =====================================================================</summary>
    public static class SwaggerExtensions
    {
        /// <summary>
        /// Configure Swagger
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static WebApplicationBuilder ConfigureSwagger(
            this WebApplicationBuilder builder)
        {
            var configuration = builder.Configuration;
            var services = builder.Services;

            // Auth0 configuration
            var domain = configuration["Auth0:Domain"];
            var audience = configuration["Auth0:Audience"];
            var isConfigured = domain != null && audience != null;

            var tokenUrl = new Uri($"https://{domain}/oauth/token");
            var authorizationUrl =
                new Uri($"https://{domain}/authorize?audience={audience}");
            var scopes = new Dictionary<string, string> { { "openid", "OpenId" } };

            // Learn more about configuring Swagger/OpenAPI at
            // https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Get the calling assembly (web service api), we'll use this
            // in AddSwaggerGen to get the path of our api (blogapi.xml file
            var assembly = Assembly.GetCallingAssembly();

            // https://www.nredko.com/articles/auth0-webapi-swagger
            builder.Services.AddSwaggerGen((options) =>
                {
                    options.SwaggerDoc("v1", new OpenApiInfo
                    {
                        Title = "API Documentation",
                        Version = "v1.0",
                        Description = ""
                    });
                    options.ResolveConflictingActions(x => x.First());

                    // If not configured we want to avoid an exception
                    if (isConfigured)
                    {
                        options.AddSecurityDefinition("oauth2",
                            new OpenApiSecurityScheme
                            {
                                Type = SecuritySchemeType.OAuth2,
                                BearerFormat = "JWT",
                                Flows = new OpenApiOAuthFlows
                                {
                                    Implicit = new OpenApiOAuthFlow
                                    {
                                        TokenUrl = tokenUrl,
                                        AuthorizationUrl = authorizationUrl,
                                        Scopes = scopes
                                    }
                                }
                            });
                    }
                    options.AddSecurityRequirement(new OpenApiSecurityRequirement {
                        {
                            new OpenApiSecurityScheme {
                                Reference = new OpenApiReference {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "oauth2"
                                }
                            },
                            new[] { "openid" }
                        }
                    });
                    // Get the name of the assembly as this will be the xml 
                    // generated file for documentation that holds our comments
                    var xmlFile = $"{assembly.GetName().Name}.xml";

                    // Include the comments in our Swagger endpoint list
                    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                    options.IncludeXmlComments(xmlPath);
                });

            return builder;
        }

        /// <summary>
        /// Use swagger middleware
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        public static WebApplication? UseSwaggerApp(this WebApplication app)
        {
            var configuration = app.Configuration;
            app.UseSwagger();

            app.UseSwaggerUI(settings =>
            {
                settings.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1.0");
                settings.OAuthClientId(configuration["Auth0:ClientId"]);
                settings.OAuthUsePkce();
            });
            return app;
        }
    }
}