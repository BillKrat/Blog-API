
using Framework.Bll.Logic;
using Framework.Dal.Sql.Logic;
using Framework.Dal.SqlLite.Logic;
using Framework.Shared.Classes;
using Framework.Shared.Enums;
using Framework.Shared.Interfaces;
using Microsoft.Extensions.Primitives;

namespace blogapi.Extensions
{
    public static class ServicesExtensions
    {
        public static WebApplicationBuilder ConfigureServices(this WebApplicationBuilder builder)
        {
            var services = builder.Services;
            var configuration = builder.Configuration;

            // User DAL registrations - singletons so the same instance used per request
            services.AddSingleton<IDal,DalSqlFacade>();
            services.AddSingleton<IDal,DalSqlLiteFacade>();

            // User BLL registration - scoped so that each request
            // we have one instance of the user
            services.AddScoped<IBll, BllFacade>();

            // Data layer transient so it can be determined each request
            services.AddTransient<IDalFacade>((provider) =>
            {
                var instance = provider.GetInstanceFromQueryStr<IDal>("Dal");
                return (IDalFacade)instance ?? new NopDal();
            });
            // Add services to the container.
            services.AddControllers()
                    .AddNewtonsoftJson(options =>
                     options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            return builder;
        }
    }
}