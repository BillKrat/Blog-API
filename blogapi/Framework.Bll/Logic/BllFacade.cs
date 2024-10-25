using Framework.Shared.Dto;
using Framework.Shared.Interfaces;

namespace Framework.Bll.Logic
{
    public class BllFacade(IDalFacade userDal) : IBll
    {
        public List<UserDto> GetUserList()
        {
           return userDal.GetUserList();
        }

    }
}
