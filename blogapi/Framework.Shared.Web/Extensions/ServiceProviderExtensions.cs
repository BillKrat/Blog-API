using Framework.Shared.Extensions;
using Framework.Shared.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace blogapi.Extensions
{
    /// <summary>======================================================================
    /// Namespace: Framework.Shared.Web
    ///  Filename: ServiceProviderExtensions.cs
    /// Developer: Billkrat
    ///   Created: 2024.10.27
    ///   Purpose: Provides a hook to the blogApi\Extensions\ServiceExtensions.cs so
    ///            multiple implementations of the same interface, e.g., IDal, can
    ///            be parsed by a named value [namedKey].  It also provides support
    ///            for the IDefaultDataProvider so that a default implementation can 
    ///            be selected if no IDal interfaces matches the named key.
    ///
    /// Author		Date	Comments
    /// ----------- ------- ----------------------------------------------------------
    ///  
    /// =====================================================================</summary>
    public static class ServiceProviderExtensions
    {
        /// <summary>
        /// Retrieve all implementations of T and then uses nameof(T) to find value
        /// </summary>
        /// <typeparam name="T">Used to retrieve all instances of T in container
        /// </typeparam>
        /// <param name="provider"></param>
        /// <param name="forControllers"></param>
        /// <returns></returns>
        public static T? GetInstanceFromQueryStrName<T>(
            this IServiceProvider provider,
            Dictionary<string, object> forControllers)
            where T : class
        {
            // Get a list of all registered versions of T, e.g., IDal
            var typeList = provider.GetServices<T>();
            var namedKey = typeof(T).Name; // "IDal" 

            // Get our request state and from it pull our parameters list
            var requestState = provider.GetService<IRequestState>();

            // Get the parameter value for namedKey "IDal", e.g., DalSqlFacade -
            // this feature is specific to BlogTopic IF the controller supports it
            if (!requestState.Parameters.ContainsKey(namedKey)
                || !forControllers.KeyValueExists(namedKey, requestState.Controller))
            {
                var defaultProvider = provider.GetService<IDefaultDataProvider>();
                if (defaultProvider != null) return (T)defaultProvider;
            }
            else  // If the controller does not support named keys then use default
            {
                var named = requestState.Parameters.GetKeyValue<string>(namedKey);

                // Iterate through our list and if we have a match - return it
                foreach (var instance in typeList)
                    if (instance.ToString().Split('.').Last() == named)
                        return instance;
            }

            return default;
        }
    }
}
