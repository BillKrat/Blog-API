using Framework.Shared.Dto;

namespace Framework.Shared.Interfaces
{
    /// <summary>======================================================================
    /// Namespace: Framework.Shared
    ///  Filename: IDalFacade.cs
    /// Developer: Billkrat
    ///   Created: 2024.10.27
    ///   Purpose: IDal implementations that serve as a data facade will implement this
    ///            if they can be used as a data facade.  The IDalFacade interface can
    ///            be used as a Transient Factory so an applicable IDal can be 
    ///            selected (see BlogApi/Extensions/ServiceExtensions for example)
    ///
    /// Author		Date	Comments
    /// ----------- ------- ----------------------------------------------------------
    ///  
    /// =====================================================================</summary>
    public interface IDalFacade : IDal
    {
        List<DataDto> GetList(EventArgs e);
    }
}
