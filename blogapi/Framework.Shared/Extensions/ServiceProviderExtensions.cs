namespace Framework.Shared.Extensions
{
    /// <summary>======================================================================
    /// Namespace: Framework.Shared
    ///  Filename: ServiceProviderExtensions.cs
    /// Developer: Billkrat
    ///   Created: 2024.10.27
    ///   Purpose: Extensions for IServiceProvider
    ///
    /// Author		Date	Comments
    /// ----------- ------- ----------------------------------------------------------
    ///  
    /// =====================================================================</summary>
    public static class ServiceProviderExtensions
    {
        public static T? Resolve<T>(this IServiceProvider provider)
        {
            object? instance = provider.GetService(typeof(T));
            if (instance == null) return default;
            return (T)instance;
        }
    }
}
