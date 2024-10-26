using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Primitives;
using System.Security.Principal;

namespace blogapi.Extensions
{
    /// <summary>
    /// 
    /// </summary>
    public static class ServiceProviderExtension
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="provider"></param>
        /// <returns></returns>
        public static T? GetInstanceFromQueryStrName<T>(this IServiceProvider provider)
            where T : class
        {
            var typeList = provider.GetServices<T>();
            var namedKey = typeof(T).Name;

            var principal = provider.GetService<IPrincipal>();

            var httpContext = provider.GetService<IHttpContextAccessor>()?.HttpContext;
            if (httpContext == null) return default;

            httpContext.Request.Query.TryGetValue(namedKey, out StringValues named);

            foreach (var instance in typeList)
                if (instance.ToString().Split('.').Last() == named) return instance;

            return default;
        }
    }
}
