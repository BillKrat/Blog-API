using Framework.Shared.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Shared.Interfaces
{
    public interface IBll
    {
        List<UserDto> GetUserList();
    }
}
