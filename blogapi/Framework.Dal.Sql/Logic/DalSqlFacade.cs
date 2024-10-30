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
    public class DalSqlFacade(IBloggingContext db) : IDalFacade, IDefaultDataProvider
    {
        public List<DataDto> GetList(EventArgs e)
        {
            var args = e as DataEventArgs<string>;
            var list = new List<DataDto>();
            list.Add(new DataDto { Data = $" DalSqlFacade: {args.Data}" });

            var dataList = db.Triples.ToList();
            foreach (var record in dataList)
            {
                list.Add(new DataDto
                {
                    Data = $"{record.Subject}  {record.Predicate}  {record.Object}"
                });
            }

            return list;
        }

    }
}
