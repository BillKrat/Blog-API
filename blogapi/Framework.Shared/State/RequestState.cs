using Framework.Shared.Interfaces;

namespace Framework.Shared.State
{
    public class RequestState : IRequestState
    {
        public RequestState()
        {
            Parameters = new Dictionary<string, string>();
        }
        public string? BaseUrl { get; set; }
        public Dictionary<string, string>? Parameters { get; set; }
        public string? Controller { get; set; }
        public string? Scheme { get; set; }
        public string? Path { get; set; }
    }
}
