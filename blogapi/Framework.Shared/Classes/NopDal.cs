using Framework.Shared.Dto;
using Framework.Shared.Interfaces;

namespace Framework.Shared.Classes
{
    public class NopDal(IRequestState? requestState) : IDal, IDalFacade
    {
        public List<DataDto> GetList(EventArgs e)
        {
            var facadeDal = requestState.Parameters["IDal"].ToString();
            return
            [
                new DataDto{ Data = "NO OPERATION "},
                new DataDto{ Data = $"[{facadeDal}] is not a supported data access layer / facade!" }
            ];
        }
    }
}
