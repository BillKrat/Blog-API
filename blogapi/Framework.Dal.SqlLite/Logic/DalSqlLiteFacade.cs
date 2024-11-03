using Framework.Shared.Dto;
using Framework.Shared.Event;
using Framework.Shared.Interfaces;

namespace Framework.Dal.SqlLite.Logic
{
    /// <summary>======================================================================
    /// Namespace: Framework.Dal.SqlLite
    ///  Filename: DalSqlLiteFacade.cs
    /// Developer: Billkrat
    ///   Created: 2024.10.27
    ///   Purpose: Data access layer facade for SqlLite
    ///
    /// Author		Date	Comments
    /// ----------- ------- ----------------------------------------------------------
    ///  
    /// =====================================================================</summary>
    public class DalSqlLiteFacade(IBloggingContext db)
        : IDalFacade, IDefaultDataProvider
    {
        public List<DataDto> GetList(EventArgs e)
        {
            var args = e as DataEventArgs<string>;
            var list = new List<DataDto>();
            list.Add(new DataDto { Data = $" DalSqlLiteFacade: [App_Data/blogging.db] {args.Data}" });

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
