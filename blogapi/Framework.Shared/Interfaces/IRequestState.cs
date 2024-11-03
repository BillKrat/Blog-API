namespace Framework.Shared.Interfaces
{
    /// <summary>======================================================================
    /// Namespace: Framework.Shared
    ///  Filename: IRequestState.cs
    /// Developer: Billkrat
    ///   Created: 2024.10.27
    ///   Purpose: Implementation contains information from the request object.  It
    ///            is populated in the Framework.Shared.Web\Extensions\Bootstrap
    ///            MiddleWareExtensions class.  A scoped instance that will provide
    ///            information as required by framework
    ///            
    /// Author		Date	Comments
    /// ----------- ------- ----------------------------------------------------------
    ///  
    /// =====================================================================</summary>
    public interface IRequestState
    {
        public string BaseUrl { get; set; }
        Dictionary<string, object> Parameters { get; set; }
        string? Controller { get; set; }
        string? Scheme { get; set; }
        string? Path { get; set; }
        string? Host { get; set; }
        int? Port { get; set; }
        string? FullHost { get; set; }
    }
}
