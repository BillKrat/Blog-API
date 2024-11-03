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
    public static class StringExtensions
    {
        public static T? To<T>(this string? objectToCast)
        {
            // Provide support for string? by converting to object?
            // and reusing its .To<T>() extension
            object? returnValue = objectToCast;
            return returnValue.To<T>();

        }

    }
}
