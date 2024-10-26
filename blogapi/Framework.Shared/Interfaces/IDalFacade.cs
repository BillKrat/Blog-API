using Framework.Shared.Dto;

namespace Framework.Shared.Interfaces
{
    public interface IDalFacade : IDal
    {
        List<UserDto> GetUserList(EventArgs e);
    }
}
