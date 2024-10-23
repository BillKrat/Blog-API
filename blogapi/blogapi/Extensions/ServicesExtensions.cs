
using Framework.Bll.Logic;
using Framework.Dal.Sql.Logic;
using Framework.Dal.SqlLite.Logic;
using Framework.Shared.Enums;
using Framework.Shared.Interfaces;

namespace blogapi.Extensions {
    public static class ServicesExtensions {


        public static WebApplicationBuilder ConfigureServices(this WebApplicationBuilder builder) {
            var services = builder.Services;
            var configuration = builder.Configuration;

            // Default provider to use
            DbProvidersEnum dbProvider = DbProvidersEnum.SqlServer;

            // User BLL registration
            services.AddTransient<IUserBll, UserBll>();

            // User DAL registrations
            services.AddTransient<UserDalSql>();
            services.AddTransient<UserDalSqlLite>();
            services.AddTransient<IUserDal>((provider) => 
                (dbProvider == DbProvidersEnum.SqlServer)
                ? provider.GetService<UserDalSql>() ?? new UserDalSql()
                : provider.GetService<UserDalSqlLite>() ?? new UserDalSqlLite()
             );


            // Add services to the container.
            services.AddControllers()
                    .AddNewtonsoftJson(options =>
                     options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            return builder;
        }
    }
}