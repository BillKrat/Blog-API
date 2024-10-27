using Framework.Shared.Dto;
using Framework.Shared.Event;
using Framework.Shared.Interfaces;

namespace Framework.Dal.Sql.Logic
{
    /// <summary>======================================================================
    /// Namespace: Framework.Dal.Sql
    ///  Filename: DalSqlFacade.cs
    /// Developer: Billkrat
    ///   Created: 2024.10.27
    ///   Purpose: Data access layer facade for SQL
    ///
    /// Author		Date	Comments
    /// ----------- ------- ----------------------------------------------------------
    ///  
    /// =====================================================================</summary>
    public class DalSqlFacade : IDalFacade, IDefaultDataProvider
    {
        public List<DataDto> GetList(EventArgs e)
        {
            var args = e as DataEventArgs<string>;
            return [new DataDto { Data = $" DalSqlFacade: {args.Data}" }];
        }

    }
}
