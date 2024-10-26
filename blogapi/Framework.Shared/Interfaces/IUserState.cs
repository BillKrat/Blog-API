namespace Framework.Shared.Interfaces
{
    public interface IUserState
    {
        bool IsAuthenticated { get; set; }
        string? Id { get; set; }
        string? UserName { get; set; }
    }
}
