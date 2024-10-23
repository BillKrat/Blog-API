using Framework.Shared.Dto;
using Framework.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Bll.Logic
{
    public class UserBll(IUserDal userDal) : IUserBll
    {
        public List<UserDto> GetUserList()
        {
           return userDal.GetUserList();
        }
    }
}
