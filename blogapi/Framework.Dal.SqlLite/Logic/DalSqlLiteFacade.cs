using Framework.Shared.Dto;
using Framework.Shared.Event;
using Framework.Shared.Interfaces;
using Microsoft.EntityFrameworkCore;

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
        public DbContext dbUtil => (DbContext)db;

        public List<DataDto> GetList(EventArgs e)
        {
            var returnList = new List<DataDto>();

            // Add the string provided by BLL
            var args = e as DataEventArgs<string>;
            returnList.Add(new DataDto { Data = args.Data });

            return returnList;
        }
    }
}
