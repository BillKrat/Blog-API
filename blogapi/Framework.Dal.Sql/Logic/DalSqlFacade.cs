using Framework.Shared.Dto;
using Framework.Shared.Event;
using Framework.Shared.Interfaces;

namespace Framework.Dal.Sql.Logic
{
    public class DalSqlFacade : IDalFacade, IDefaultDataProvider
    {
        public List<DataDto> GetList(EventArgs e)
        {
            var args = e as DataEventArgs<string>;
            return [new DataDto { Data = $" DalSqlFacade: {args.Data}" }];
        }

    }
}
