using Framework.Shared.Interfaces;

namespace Framework.Shared.State
{
    /// <summary>======================================================================
    /// Namespace: Framework.Shared
    ///  Filename: UserState.cs
    /// Developer: Billkrat
    ///   Created: 2024.10.27
    ///   Purpose: Instance contains information from the IPincipal Instance. It
    ///            is populated in the Framework.Shared.Web\Extensions\Bootstrap
    ///            MiddleWareExtensions class.  A scoped instance that will provide
    ///            information as required by framework
    ///            
    /// Author		Date	Comments
    /// ----------- ------- ----------------------------------------------------------
    ///  
    /// =====================================================================</summary>
    public class UserState : IUserState
    {
        public bool IsAuthenticated { get; set; }
        public string? Id { get; set; }
        public string? UserName { get; set; } = "NOT IMPLEMENTED [yet]";
    }
}
