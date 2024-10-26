using Framework.Shared.Interfaces;

namespace Framework.Shared.State
{
    public class UserState : IUserState
    {
        public bool IsAuthenticated { get; set; }
        public string? Id { get; set; }
        public string? UserName { get; set; }
    }
}
