
namespace blogapi.Extensions {
    public static class ServicesExtensions {
        public static WebApplicationBuilder ConfigureServices(this WebApplicationBuilder builder) {
            var services = builder.Services;
            var configuration = builder.Configuration;

            // Add services to the container.
            services.AddControllers()
                    .AddNewtonsoftJson(options =>
                     options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            return builder;
        }
    }
}