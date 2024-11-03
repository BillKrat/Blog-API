namespace Framework.Shared.Extensions
{
    /// <summary>======================================================================
    //\ Namespace: Framework.Shared
    //\  Filename: ObjectExtensions.cs
    //\ Developer: Billkrat
    //\   Created: 2024.10.27
    //\   Purpose: Extensions for object? 
    ///
    /// Author		Date	Comments
    /// ----------- ------- ----------------------------------------------------------
    /// 
    /// =====================================================================</summary>
    public static class ObjectExtensions
    {
        public static T? To<T>(this object? objectToCast)
        {
            object? returnValue = default(T);

            if (objectToCast is T) return (T?)objectToCast;
            switch (typeof(T).FullName)
            {
                case "System.Boolean": returnValue = objectToCast == null ? false : Boolean.Parse($"{objectToCast}"); break;
                case "System.String": returnValue = $"{objectToCast}"; break;
            }
            return (T?)returnValue;
        }
    }
}
