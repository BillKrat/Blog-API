
using Framework.Bll.Logic;
using Framework.Dal.Sql.Logic;
using Framework.Dal.SqlLite.Logic;
using Framework.Shared.Classes;
using Framework.Shared.Interfaces;
using Framework.Shared.Mocks.Dal;

namespace blogapi.Extensions
{
    public static class ServicesExtensions
    {
        public static WebApplicationBuilder ConfigureServices(this WebApplicationBuilder builder)
        {
            var services = builder.Services;
            var configuration = builder.Configuration;

            // User BLL registration - scoped so that each request
            // we have one instance of the user
            services.AddScoped<IBll, BllFacade>();

            // User IDal registrations - singletons so the same instance used
            services.AddSingleton<IDal, DalSqlFacade>();
            services.AddSingleton<IDal, DalSqlLiteFacade>();
            services.AddSingleton<IDal, DalWeatherForecast>();

            // Data layer transient so it can be determined each request
            services.AddTransient<IDalFacade>((provider) => {
                // FOR DEVELOPMENT PURPOSES ONLY - until framework evolves to permit real world
                // usage. The Request https://localhost:5175/User?IDal=DalSqlFacade would result
                // in an instance of DalSqlFacade being returned because it is registered above
                var instance = provider.GetInstanceFromQueryStr<IDal>();
                return (IDalFacade?) instance ?? new NopDal();
            });

            // Add services to the container.
            services.AddControllers()
                    .AddNewtonsoftJson(options =>
                     options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            return builder;
        }
    }
}