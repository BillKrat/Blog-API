using Framework.Shared.Dto;
using Framework.Shared.Event;
using Framework.Shared.Interfaces;
using System.Text.Json;

namespace Feature.BlogTopic
{
    /// <summary>======================================================================
    /// Namespace: Feature.BlogTopic
    ///  Filename: BllBlogTopic.cs
    /// Developer: BillKrat
    ///   Created: date
    ///   Purpose: Logic for blogs that will reference API
    ///
    /// Author		Date	Comments
    /// ----------- ------- ----------------------------------------------------------
    ///  
    /// =====================================================================</summary>
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
