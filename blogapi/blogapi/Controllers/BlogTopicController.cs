using Feature.BlogTopic;
using Framework.Shared.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace blogapi.Controllers;

/// <summary>
/// Blog Topic Controller
/// </summary>
/// <param name="bll"></param>
[Authorize]
[ApiController]
[Route("[controller]")]
public class BlogTopicController([FromKeyedServices(BlogTopicConstants.BlogTopic)] IBll bll)
{

    /// <summary>
    /// DalWeatherForecast, DalSqlFacade, and DalSqlLiteFacade supported
    /// </summary>
    /// <param name="IDal">Specifies the interface to pull implementation list for</param>
    /// <returns></returns>
    [AllowAnonymous]
    [HttpGet("DalSwap")]
    public dynamic Get(string IDal)
    {
        return bll.GetList();
    }
}
