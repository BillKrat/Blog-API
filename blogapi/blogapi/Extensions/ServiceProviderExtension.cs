using Framework.Shared.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.Primitives;
using static System.Net.WebRequestMethods;

namespace blogapi.Extensions
{
    public static class ServiceProviderExtension
    {
        public static T GetInstanceFromQueryStr<T>(this IServiceProvider provider)
            where T : class
        {
            var typeList = provider.GetServices<T>();
            var namedKey = typeof(T).Name;

            StringValues named;
            var httpContext = provider.GetService<IHttpContextAccessor>().HttpContext;
            httpContext.Request.Query.TryGetValue(namedKey, out named);

            foreach (var instance in typeList)
            {
                if (instance.ToString().Split('.').Last() == named)
                {
                    return instance;
                }
            }
            return null;
        }
    }
}
