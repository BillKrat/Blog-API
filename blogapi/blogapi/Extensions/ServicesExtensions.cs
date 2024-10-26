using Feature.BlogTopic;
using Framework.Bll.Logic;
using Framework.Dal.Sql.Logic;
using Framework.Dal.SqlLite.Logic;
using Framework.Shared.Classes;
using Framework.Shared.Constants;
using Framework.Shared.Extensions;
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
            services.AddTransient<IPrincipal>((provider) =>
                provider.GetRequiredService<IHttpContextAccessor>().HttpContext.User);

            // Configured in middleware
            services.AddScoped<IUserState, UserState>();
            services.AddScoped<IRequestState, RequestState>();

            // User BLL registrations - scoped to enable dynamic replacement
            services.AddKeyedScoped<IBll, BllBlogTopic>(BlogTopicConstants.BlogTopic);
            services.AddKeyedScoped<IBll, BllDataFacade>(FrameworkConstants.DataFacade);

            // User IDal registrations - singletons so the same instance used 
            services.AddTransient<IDal, DalSqlFacade>();
            services.AddTransient<IDal, DalSqlLiteFacade>();
            services.AddTransient<IDal, DalWeatherForecast>();

            // Default data provider
            services.AddScoped<IDefaultDataProvider, DalSqlFacade>();

            // Data layer transient so it can be determined each request
            services.AddTransient<IDalFacade>((provider) =>
            {
                // Get the data facade to use for IDal which is registered numerous classes. If the
                // controller is BlogTopic then the parameter IDal will be used to determine the instance,
                // e.g., ?IDal=DalSqlFacade.  Otherwise the IDefaultDataProvider (above) will be used.
                var instance = provider.GetInstanceFromQueryStrName<IDal>();
                var requestState = provider.Resolve<IRequestState>();
                return (IDalFacade?)instance ?? new NopDal(requestState);
            });

            // Add services to the container.
            services.AddControllers()
                    .AddNewtonsoftJson(options =>
                     options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            return builder;
        }
    }
}