namespace Framework.Shared.Extensions
{
    public static class ServiceProviderExtensions
    {
        public static T? Resolve<T>(this IServiceProvider provider)
        {
            object instance = provider.GetService(typeof(T));
            if (instance == null) return default;
            return (T)instance;
        }
    }
}
