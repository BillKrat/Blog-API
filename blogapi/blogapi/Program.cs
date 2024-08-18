// https://learn.microsoft.com/en-us/aspnet/core/tutorials/first-web-api?view=aspnetcore-8.0&tabs=visual-studio-code
using System.Reflection;
using blogapi.Controllers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;


var builder = WebApplication.CreateBuilder(args);

var Configuration = builder.Configuration;


// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(
    options => options.UseInMemoryDatabase("AppDb"));

builder.Services.AddAuthorization();
builder.Services.AddIdentityApiEndpoints<IdentityUser>().
         AddEntityFrameworkStores<ApplicationDbContext>();

var domain = Configuration["Auth0:Domain"];
var audience = Configuration["Auth0:Audience"];

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
              Implicit  = new OpenApiOAuthFlow
              {
                  TokenUrl = new Uri($"https://{domain}/oauth/token"),
                  AuthorizationUrl = new Uri($"https://{domain}/authorize?audience={audience}"),
                  Scopes = new Dictionary<string, string>
                  {
                      { "openid", "OpenId" },
                  }
              }
          }
      });
      options.AddSecurityRequirement(new OpenApiSecurityRequirement
      {
          {
              new OpenApiSecurityScheme
              {
                  Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "oauth2" }
              },
              new[] { "openid" }
          }
      });
      var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
      var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
      //options.IncludeXmlComments(xmlPath);
  });         

var app = builder.Build();

app.MapIdentityApi<IdentityUser>();

var config = app.Services.GetService<IConfiguration>();
var connect = config?.GetValue<string>("gwnconnection");

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") 
    ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

// https://learn.microsoft.com/en-us/ef/core/dbcontext-configuration/
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
      app.UseSwaggerUI(settings =>
  {
      settings.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1.0");
      settings.OAuthClientId(Configuration["Auth0:ClientId"]);
      settings.OAuthClientSecret(Configuration["Auth0:ClientSecret"]);
      settings.OAuthUsePkce();
  });
}

app.UseHttpsRedirection();
app.MapGet("/weatherforecast", () => new WeatherForecastController().Get())
    .WithName("GetWeatherForecast")
    .WithOpenApi()
    //.RequireAuthorization()
    ;

app.MapGet("/authorize", () => new MyAuthorizeController().Get())
    .WithName("GetAuthorization")
    .WithOpenApi();


//app.MapSwagger().RequireAuthorization();

app.MapPost("/triplestore", (string payload) => {return payload; })
    .WithName("getTripleStore")
    .WithOpenApi();

app.Run();
