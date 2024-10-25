
using System.Reflection;
using Microsoft.OpenApi.Models;

namespace blogapi.Extensions {
    public static class SwaggerExtensions {
        public static WebApplicationBuilder ConfigureSwagger(this WebApplicationBuilder builder) {
            var configuration = builder.Configuration;

            var services = builder.Services;
            var domain = configuration["Auth0:Domain"];
            var audience = configuration["Auth0:Audience"];

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            if (domain != null && audience != null)
            {
                // https://www.nredko.com/articles/auth0-webapi-swagger
                builder.Services.AddSwaggerGen(options =>
                    {
                        options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                        {
                            Title = "API Documentation",
                            Version = "v1.0",
                            Description = ""
                        });

                        options.ResolveConflictingActions(x => x.First());

                        options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                        {
                            Type = SecuritySchemeType.OAuth2,
                            BearerFormat = "JWT",
                            Flows = new OpenApiOAuthFlows
                            {
                                Implicit = new OpenApiOAuthFlow
                                {
                                    TokenUrl = new Uri($"https://{domain}/oauth/token"),
                                    AuthorizationUrl = new Uri($"https://{domain}/authorize?audience={audience}"),
                                    Scopes = new Dictionary<string, string> { { "openid", "OpenId" } }                                
                                }
                            }
                        });

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
                    });
            }
            return builder;
        }

        public static WebApplication? UseSwaggerApp(this WebApplication app){
            var configuration = app.Configuration;    
            app.UseSwagger();
            app.UseSwaggerUI(settings =>  {
                settings.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1.0");
                settings.OAuthClientId(configuration["Auth0:ClientId"]);
                settings.OAuthClientSecret(configuration["Auth0:ClientSecret"]);
                settings.OAuthUsePkce();
            });
            return app;
        }
    }
}