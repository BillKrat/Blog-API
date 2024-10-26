using Framework.Shared.Dto;
using Framework.Shared.Event;
using Framework.Shared.Interfaces;

namespace Framework.Dal.Sql.Logic
{
    public class DalSqlFacade : IDalFacade
    {
        public List<UserDto> GetUserList(EventArgs e)
        {
            var args = e as DataEventArgs<string>;
            return [new UserDto { Data = $" DalSqlFacade: {args.Data}" }];
        }

    }
}
