﻿using Framework.Shared.Dto;

namespace Framework.Shared.Interfaces
{
    public interface IBll
    {
        List<UserDto> GetUserList();
    }
}
