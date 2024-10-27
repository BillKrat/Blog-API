using Framework.Shared.Dto;
using Framework.Shared.Interfaces;

namespace Framework.Shared.Classes
{
    /// <summary>======================================================================
    /// Namespace: Framework.Shared
    ///  Filename: NopDal.cs
    /// Developer: Billkrat
    ///   Created: 2024.10.27
    ///   Purpose: NOP (No operation) for IDal [fallback]
    ///
    /// Author		Date	Comments
    /// ----------- ------- ----------------------------------------------------------
    ///  
    /// =====================================================================</summary>
    public class NopDal(IRequestState? requestState) : IDal, IDalFacade
    {
        public List<DataDto> GetList(EventArgs e)
        {
            var facadeDal = requestState.Parameters["IDal"].ToString();
            return
            [
                new DataDto{ Data = "NO OPERATION "},
                new DataDto{ Data = $"[{facadeDal}] is not a supported!" }
            ];
        }
    }
}
