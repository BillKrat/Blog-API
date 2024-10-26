using Framework.Shared.Dto;
using Framework.Shared.Event;
using Framework.Shared.Interfaces;

namespace Framework.Dal.SqlLite.Logic
{
    public class DalSqlLiteFacade : IDalFacade
    {
        public List<UserDto> GetUserList(EventArgs e)
        {
            var args = e as DataEventArgs<string>;
            return [new UserDto { Data = $" DalSqlLiteFacade: {args.Data}" }];
        }
    }
}
