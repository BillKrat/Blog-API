using Framework.Shared.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace blogapi.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")] 
public class UserController(IBll bll)
{
    [HttpGet]
    public dynamic Get(string IDal)
    {
        return bll.GetUserList();
    }
}
