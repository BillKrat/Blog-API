using Framework.Shared.Dto;
using Framework.Shared.Event;
using Framework.Shared.Interfaces;
using System.Text.Json;

namespace Framework.Bll.Logic
{
    /// <summary>
    /// Intended for blog topic online example
    /// </summary>
    /// <param name="dataAccessLayer"></param>
    /// <param name="user"></param>
    public class BllBlogTopic(IDalFacade dataAccessLayer, IUserState user) : IBll
    {
        /// <summary>
        /// Get list for the blog topic
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
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
