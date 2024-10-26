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
            // We'll use this in the Shared.Web\Extensions\Bootstrap\MiddleWareExtensions
            // useSharedMiddleWare() function to populate the UserState object
            services.AddHttpContextAccessor();
            services.AddScoped<IPrincipal>((provider) =>
                provider.GetRequiredService<IHttpContextAccessor>().HttpContext.User);

            // The following scoped parameters are configured in the Shared.Web\Bootstrap
            // MiddleWareExtensions for UseSharedMiddleWare function (invoked in Program)
            services.AddScoped<IUserState, UserState>();
            services.AddScoped<IRequestState, RequestState>();

            // BLL - key scoped so we can configure BLL for controller using FromKeyedServices
            // attribute, e.g., The BlogTopicController has a primary constructor as follows:
            //
            //     BlogTopicController([FromKeyedServices(BlogTopicConstants.BlogTopic)] IBll bll)
            //
            services.AddKeyedScoped<IBll, BllBlogTopic>(BlogTopicConstants.BlogTopic);
            services.AddKeyedScoped<IBll, BllDataFacade>(FrameworkConstants.DataFacade);

            // User IDal - when IDalFacade is resolved an instance of IDal will be returned
            services.AddTransient<IDal, DalSqlFacade>();
            services.AddTransient<IDal, DalSqlLiteFacade>();
            services.AddTransient<IDal, DalWeatherForecast>();

            // Default data provider to use for data operations
            services.AddScoped<IDefaultDataProvider, DalSqlLiteFacade>();

            // Data layer transient - this will allow the data layer facade to be
            // determined each time IDalFacade is resolved
            services.AddTransient<IDalFacade>((provider) =>
            {
                // GetInstanceFromQueryStrName requires an opt-in since parameters
                // have the ability to change data access layer - currently we only
                // opt-in for BlogTopic controller which will be used to demo Blog topics
                var forControllers = new Dictionary<string, object>{
                    { nameof(IDal), BlogTopicConstants.BlogTopic }
                };

                // Get the data facade to use for IDal which has numerous implementations
                // registered (above). If the controller is BlogTopic then the parameter IDal
                // will be used to determine the instance, e.g., ?IDal=DalSqlFacade.  Otherwise
                // the configured IDefaultDataProvider [registered above] will be used.
                var dal = provider.GetInstanceFromQueryStrName<IDal>(forControllers);

                // Note that if an unsupported IDal is requested that dal will be null.  As a
                // result we use "new"j for NopDal so we have to provide the resolved parameter
                return (IDalFacade?)dal ?? new NopDal(provider.Resolve<IRequestState>());
            });

            // Add services to the container.
            services.AddControllers()
                    .AddNewtonsoftJson(options =>
                     options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            return builder;
        }
    }
}