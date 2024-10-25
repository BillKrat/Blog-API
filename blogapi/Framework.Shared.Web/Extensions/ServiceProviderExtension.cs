using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Primitives;

namespace blogapi.Extensions
{
    public static class ServiceProviderExtension
    {
        public static T? GetInstanceFromQueryStrName<T>(this IServiceProvider provider)
            where T : class
        {
            var typeList = provider.GetServices<T>();
            var namedKey = typeof(T).Name;

            var httpContext = provider.GetService<IHttpContextAccessor>()?.HttpContext;
            if (httpContext == null) return default;

            httpContext.Request.Query.TryGetValue(namedKey, out StringValues named);

            foreach (var instance in typeList)
                if (instance.ToString().Split('.').Last() == named) return instance;

            return default;
        }
    }
}
