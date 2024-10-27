namespace Framework.Shared.Extensions
{
    public static class ObjectExtensions
    {
        public static T? To<T>(this object? objectToCast)
        {
            object? returnValue = default(T);

            if (objectToCast is T) return (T?)objectToCast;
            switch (typeof(T).FullName)
            {
                case "System.String": returnValue = $"{objectToCast}"; break;
            }
            return (T?)returnValue;
        }
    }
}
