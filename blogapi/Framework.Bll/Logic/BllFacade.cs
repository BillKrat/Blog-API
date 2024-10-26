using Framework.Shared.Dto;
using Framework.Shared.Event;
using Framework.Shared.Interfaces;
using System.Text.Json;

namespace Framework.Bll.Logic
{
    public class BllFacade(IDalFacade userDal, IUserState user) : IBll
    {
        public List<UserDto> GetUserList()
        {
            // BLL will grab the user information from primary constructor
            // and set the json information in data parameter
            var identityStr = JsonSerializer.Serialize(user);
            var datapara = new DataEventArgs<string>(identityStr);

            return userDal.GetUserList(datapara);
        }

    }
}
