
namespace Framework.Shared.Event
{
    /// <summary>======================================================================
    /// Namespace: Framework.Shared
    ///  Filename: DataEventArgs.cs
    /// Developer: Billkrat
    ///   Created: 2024.10.27
    ///   Purpose: Generic data event args that holds type of T
    ///
    /// Author		Date	Comments
    /// ----------- ------- ----------------------------------------------------------
    ///  
    /// =====================================================================</summary>
    public class DataEventArgs<T>(T data) : EventArgs
    {
        public T? Data { get; set; } = data;
    }
}
