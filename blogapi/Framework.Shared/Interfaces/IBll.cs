using Framework.Shared.Dto;

namespace Framework.Shared.Interfaces
{
    /// <summary>======================================================================
    /// Namespace: Framework.Shared
    ///  Filename: IBll.cs
    /// Developer: Billkrat
    ///   Created: 2024.10.27
    ///   Purpose: Business logic layer interface 
    ///
    /// Author		Date	Comments
    /// ----------- ------- ----------------------------------------------------------
    ///  
    /// =====================================================================</summary>
    public interface IBll
    {
        List<DataDto> GetList();
    }
}
