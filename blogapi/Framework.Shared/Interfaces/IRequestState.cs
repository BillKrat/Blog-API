namespace Framework.Shared.Interfaces
{
    public interface IRequestState
    {
        public string BaseUrl { get; set; }
        Dictionary<string, string> Parameters { get; set; }
    }
}
