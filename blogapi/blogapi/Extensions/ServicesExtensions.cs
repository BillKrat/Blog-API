
using Framework.Bll.Logic;
using Framework.Dal.Sql.Logic;
using Framework.Dal.SqlLite.Logic;
using Framework.Shared.Classes;
using Framework.Shared.Interfaces;
using Framework.Shared.Mocks.Dal;
using Framework.Shared.State;
using System.Security.Principal;

namespace blogapi.Extensions
{
    /// <summary>
    /// Invoked by Program.cs
    /// </summary>
    public static class ServicesExtensions
    {
        /// <summary>
        /// Configure services in container
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static WebApplicationBuilder ConfigureServices(this WebApplicationBuilder builder)
        {
            var services = builder.Services;
            var configuration = builder.Configuration;

            // Event if not authenticated the IPrincipal instance will be available
            services.AddHttpContextAccessor();
            services.AddTransient<IPrincipal>((provider) => provider.GetRequiredService<IHttpContextAccessor>().HttpContext.User);

            // Configured in middleware
            services.AddScoped<IUserState, UserState>();
            services.AddScoped<IRequestState, RequestState>();

            // User BLL registration - scoped so that each request will have new instance
            // allowing for dynamic configuration of BLL per request
            services.AddScoped<IBll, BllFacade>();

            // User IDal registrations - singletons so the same instance used 
            services.AddTransient<IDal, DalSqlFacade>();
            services.AddTransient<IDal, DalSqlLiteFacade>();
            services.AddTransient<IDal, DalWeatherForecast>();

            // Data layer transient so it can be determined each request
            services.AddTransient<IDalFacade>((provider) =>
            {
                // FOR DEVELOPMENT PURPOSES ONLY - until framework evolves to permit real world
                // usage. The Request https://localhost:5175/User?IDal=DalSqlFacade would result
                // in an instance of DalSqlFacade being returned because it is registered above
                var instance = provider.GetInstanceFromQueryStrName<IDal>();
                return (IDalFacade?)instance ?? new NopDal();
            });

            // Add services to the container.
            services.AddControllers()
                    .AddNewtonsoftJson(options =>
                     options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            return builder;
        }
    }
}