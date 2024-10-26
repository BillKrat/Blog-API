// https://learn.microsoft.com/en-us/aspnet/core/tutorials/first-web-api?view=aspnetcore-8.0&tabs=visual-studio-code
using blogapi.Extensions;
using Framework.Shared.Extensions.Bootstrap;
using Framework.Shared.Web.Extensions.Bootstrap;

var builder = WebApplication
    .CreateBuilder(args)
    .ConfigureServices() // blogapi/Extensions/ServiceExtensions
    .ConfigureSecurity() // Framework.Shared.Web/Bootstrap/SecurityExtensions
    .ConfigureSwagger(); // Framework.Shared.Web/Bootstrap/SwaggerExtensions

var app = builder.Build();

app.UseSharedMiddleWare();

if (app.Environment.IsDevelopment())
{
    app.UseSwaggerApp();
}
app.UseCors(builder => builder
       .AllowAnyHeader()
       .AllowAnyMethod()
       .AllowAnyOrigin()
    );

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();

