// https://learn.microsoft.com/en-us/aspnet/core/tutorials/first-web-api?view=aspnetcore-8.0&tabs=visual-studio-code
using blogapi.Extensions;

var builder = WebApplication
    .CreateBuilder(args)
    .ConfigureContext()
    .ConfigureSecurity()
    .ConfigureServices()
    .ConfigureSwagger();

var app = builder.Build();

if(app.Environment.IsDevelopment())
{
    app.UseSwaggerApp();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();

