using Framework.Shared.Interfaces;

namespace Framework.Shared.State
{
    /// <summary>======================================================================
    /// Namespace: Framework.Shared
    ///  Filename: RequestState.cs
    /// Developer: Billkrat
    ///   Created: 2024.10.27
    ///   Purpose: Instance contains information from the request object.  It
    ///            is populated in the Framework.Shared.Web\Extensions\Bootstrap
    ///            MiddleWareExtensions class.  A scoped instance that will provide
    ///            information as required by framework
    ///   
    ///
    /// Author		Date	Comments
    /// ----------- ------- ----------------------------------------------------------
    ///  
    /// =====================================================================</summary>
    /// <summary>
    /// 
    /// </summary>
    public class RequestState : IRequestState
    {
        public required string BaseUrl { get; set; }
        public Dictionary<string, object> Parameters { get; set; } = [];
        public string? Controller { get; set; }
        public string? Scheme { get; set; }
        public string? Path { get; set; }
    }
}
