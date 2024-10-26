namespace Framework.Shared.Interfaces
{
    public interface IRequestState
    {
        public string BaseUrl { get; set; }
        Dictionary<string, string> Parameters { get; set; }
        string? Controller { get; set; }
        string? Scheme { get; set; }
        string? Path { get; set; }
    }
}
