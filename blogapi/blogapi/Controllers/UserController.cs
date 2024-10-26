using Framework.Shared.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace blogapi.Controllers;

/// <summary>
/// User Controller
/// </summary>
/// <param name="bll"></param>
[Authorize]
[ApiController]
[Route("[controller]")]
public class UserController(IBll bll)
{
    /// <summary>
    /// DalWeatherForecast, DalSqlFacade, and DalSqlLiteFacade supported
    /// </summary>
    /// <param name="IDal">Specifies the interface to pull implementation list for</param>
    /// <returns></returns>
    [AllowAnonymous]
    [HttpGet]
    public dynamic Get(string IDal)
    {
        return bll.GetUserList();
    }
}
