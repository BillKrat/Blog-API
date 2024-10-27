using Framework.Shared.Constants;
using Framework.Shared.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace blogapi.Controllers
{
    /// <summary>======================================================================
    /// Namespace: Framework.
    ///  Filename: RestController.cs
    /// Developer: Billkrat
    ///   Created: 2024.10.27
    ///   Purpose: Standard rest controller
    ///
    /// Author		Date	Comments
    /// ----------- ------- ----------------------------------------------------------
    /// 
    /// =====================================================================</summary>
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class RestController([FromKeyedServices(FrameworkConstants.DataFacade)] IBll bll)
    {
        /// <summary>
        /// Get data from the Data Facade
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet("List")]
        public dynamic GetList()
        {
            return bll.GetList();
        }

    }
}
