// https://learn.microsoft.com/en-us/aspnet/core/tutorials/first-web-api?view=aspnetcore-8.0&tabs=visual-studio-code
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(
    options => options.UseInMemoryDatabase("AppDb"));

builder.Services.AddAuthorization();
builder.Services.AddIdentityApiEndpoints<IdentityUser>().
         AddEntityFrameworkStores<ApplicationDbContext>();

var app = builder.Build();
app.MapIdentityApi<IdentityUser>();

var config = app.Services.GetService<IConfiguration>();
var connect = config?.GetValue<string>("gwnconnection");


// https://learn.microsoft.com/en-us/ef/core/dbcontext-configuration/
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/weatherforecast", () => new WeatherForecastController().Get())
    .WithName("GetWeatherForecast")
    .WithOpenApi()
    .RequireAuthorization()
    ;
    
//app.MapSwagger().RequireAuthorization();

app.MapPost("/triplestore", (string payload) => {return payload; })
    .WithName("getTripleStore")
    .WithOpenApi();

app.Run();
