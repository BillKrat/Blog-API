using Feature.BlogTopic;
using Framework.Shared.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace blogapi.Controllers
{
    /// <summary>======================================================================
    /// Namespace: BlogApi
    ///  Filename: BlogTopicController.cs
    /// Developer: Billkrat
    ///   Created: 2024.10.27
    ///   Purpose: Controller for handling services that will support blog topics
    ///            that developer can access (referenced by Blog entry)
    ///
    /// Author		Date	Comments
    /// ----------- ------- ----------------------------------------------------------
    /// 
    /// =====================================================================</summary>
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class BlogTopicController(
        [FromKeyedServices(BlogTopicConstants.BlogTopic)] IBll bll)
    {
        /// <summary>
        /// DalWeatherForecast, DalSqlFacade, and DalSqlLiteFacade supported
        /// </summary>
        /// <param name="IDal">Specifies the interface to pull implementation list 
        /// for, e.g., DalWeatherForecast, DalSqlLiteFacade and DalSqlFacade
        /// </param>
        /// <returns>Although it appears as though IDal is not used [in code] it 
        /// becomes part of the parameter  query list which is used by framework
        /// </returns>
        [AllowAnonymous]
        [HttpGet("DalSwap")]
        public dynamic Get(string IDal)
        {
            return bll.GetList();
        }
    }
}