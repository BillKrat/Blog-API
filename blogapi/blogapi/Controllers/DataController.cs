using Framework.Shared.Constants;
using Framework.Shared.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace blogapi.Controllers
{
    /// <summary>
    /// Generic Data Controller
    /// </summary>
    /// <param name="bll"></param>
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class DataController([FromKeyedServices(FrameworkConstants.DataFacade)] IBll bll)
    {
        /// <summary>
        /// Get data from the Data Facade
        /// </summary>
        /// <param name="IDal"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet("List")]
        public dynamic GetList()
        {
            return bll.GetList();
        }

    }
}
