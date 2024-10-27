namespace Framework.Shared.Interfaces
{
    /// <summary>======================================================================
    /// Namespace: Framework.Shared
    ///  Filename: IUserState.cs
    /// Developer: Billkrat
    ///   Created: 2024.10.27
    ///   Purpose: Implementation contains information from the IPincipal Instance. It
    ///            is populated in the Framework.Shared.Web\Extensions\Bootstrap
    ///            MiddleWareExtensions class.  A scoped instance that will provide
    ///            information as required by framework
    ///               
    /// Author		Date	Comments
    /// ----------- ------- ----------------------------------------------------------
    ///  
    /// =====================================================================</summary>
    public interface IUserState
    {
        bool IsAuthenticated { get; set; }
        string? Id { get; set; }
        string? UserName { get; set; }
    }
}
