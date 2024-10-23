using Framework.Shared.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace blogapi.Controllers; 

//[Authorize]
[ApiController]
[Route("[controller]")] // Piggy back on WeatherForecast with our IUserBll
public class WeatherForecastController(IUserBll userBll) {
    [HttpGet]
    public dynamic Get()
    {
        return userBll.GetUserList();
    }
}
