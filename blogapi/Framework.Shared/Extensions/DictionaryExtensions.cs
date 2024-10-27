namespace Framework.Shared.Extensions
{
    /// <summary>======================================================================
    /// Namespace: Framework.Shared
    ///  Filename: DictionaryExtensions.cs
    /// Developer: Billkrat
    ///   Created: 2024.10.27
    ///   Purpose: Dictionary<string,object> extensions
    ///
    /// Author		Date	Comments
    /// ----------- ------- ----------------------------------------------------------
    ///  
    /// =====================================================================</summary>
    public static class DictionaryExtensions
    {
        public static T? GetKeyValue<T>(
            this Dictionary<string, object> dictionary,
            string key,
            T? defaultIfNotDefined = default)
        {
            if (dictionary == null || !dictionary.TryGetValue(key, out object? value))
                return defaultIfNotDefined;

            return value.To<T>();
        }

        public static bool KeyValueExists(
            this Dictionary<string, object> dictionary,
            string key, object? value)
        {
            bool isMatch = false;
            if (dictionary == null) return false;

            if (dictionary.TryGetValue(key, out object? keyValue))
                isMatch = value.Equals(keyValue);

            return isMatch;
        }


    }
}
