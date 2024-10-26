using Framework.Shared.Dto;
using Framework.Shared.Interfaces;

namespace Framework.Shared.Classes
{
    public class NopDal : IDal, IDalFacade
    {
        public List<UserDto> GetUserList(EventArgs e)
        {
            return new List<UserDto>
            {

            };
        }
    }
}
