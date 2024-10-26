
namespace Framework.Shared.Event
{
    public class DataEventArgs<T>(T data) : EventArgs
    {
        public T? Data { get; set; } = data;
    }
}
