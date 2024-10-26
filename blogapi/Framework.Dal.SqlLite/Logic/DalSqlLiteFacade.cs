using Framework.Shared.Dto;
using Framework.Shared.Event;
using Framework.Shared.Interfaces;

namespace Framework.Dal.SqlLite.Logic
{
    public class DalSqlLiteFacade : IDalFacade, IDefaultDataProvider
    {
        public List<DataDto> GetList(EventArgs e)
        {
            var args = e as DataEventArgs<string>;
            return [new DataDto { Data = $" DalSqlLiteFacade: {args.Data}" }];
        }
    }
}
