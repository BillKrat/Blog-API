namespace Framework.Shared.Extensions
{
    public static class DictionaryExtensions
    {
        public static T? GetKeyValue<T>(
            this Dictionary<string, object> dictionary,
            string key,
            T? defaultIfNotDefined = default)
        {
            if (dictionary == null || !dictionary.TryGetValue(key, out object? value))
                return defaultIfNotDefined;

            return (T)value;
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
