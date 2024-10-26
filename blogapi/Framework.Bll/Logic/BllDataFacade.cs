using Framework.Shared.Dto;
using Framework.Shared.Event;
using Framework.Shared.Interfaces;
using System.Text.Json;

namespace Framework.Bll.Logic
{
    /// <summary>
    /// CRUDL Facade for managing the Blog 
    /// </summary>
    /// <param name="dataAccessLayer"></param>
    /// <param name="user"></param>
    public class BllDataFacade(IDalFacade dataAccessLayer, IUserState user) : IBll
    {
        /// <summary>
        /// Get list from the selected data access layer
        /// </summary>
        /// <returns></returns>
        public List<DataDto> GetList()
        {
            // BLL will grab the user information from primary constructor
            // and set the json information in data parameter
            var identityStr = JsonSerializer.Serialize(user);
            var datapara = new DataEventArgs<string>(identityStr);

            return dataAccessLayer.GetList(datapara);
        }

    }
}
