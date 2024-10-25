using Framework.Shared.Dto;
using Framework.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Shared.Classes
{
    public class NopDal : IDal, IDalFacade
    {
        public List<UserDto> GetUserList()
        {
            return new List<UserDto>
            {
                
            };
        }
    }
}
