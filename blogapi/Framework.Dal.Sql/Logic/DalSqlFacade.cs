using Framework.Shared.Dto;
using Framework.Shared.Interfaces;

namespace Framework.Dal.Sql.Logic
{
    public class DalSqlFacade : IDalFacade
    {
        public List<UserDto> GetUserList()
        {
            return [new() { Data = "Sql User" }];
        }

    }
}
