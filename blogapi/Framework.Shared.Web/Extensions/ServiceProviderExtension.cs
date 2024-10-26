using Feature.BlogTopic;
using Framework.Shared.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace blogapi.Extensions
{
    /// <summary>
    /// Service provider extensions
    /// </summary>
    public static class ServiceProviderExtension
    {
        /// <summary>
        /// Retrieve all implementations of T and then uses nameof(T) to find value
        /// </summary>
        /// <typeparam name="T">Used to retrieve all instances of T in container</typeparam>
        /// <param name="provider"></param>
        /// <returns></returns>
        public static T? GetInstanceFromQueryStrName<T>(this IServiceProvider provider)
            where T : class
        {
            // Get a list of all registered versions of T, e.g., IDal
            var typeList = provider.GetServices<T>();
            var namedKey = typeof(T).Name; // "IDal" 

            // Get our request state and from it pull our parameters list
            var requestState = provider.GetService<IRequestState>();

            // Get the parameter value for namedKey "IDal", e.g., DalSqlFacade - this feature is specific to BlogTopic
            if (requestState.Parameters.ContainsKey(namedKey) && requestState.Controller == BlogTopicConstants.BlogTopic)
            {
                var named = requestState.Parameters[namedKey];

                // Iterate through our list and if we have a match - return it
                foreach (var instance in typeList)
                    if (instance.ToString().Split('.').Last() == named) return instance;
            }
            else
            {
                var defaultProvider = provider.GetService<IDefaultDataProvider>();
                if (defaultProvider != null) return (T)defaultProvider;
            }

            return default;
        }
    }
}
