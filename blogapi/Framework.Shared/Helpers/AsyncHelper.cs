namespace Framework.Shared.Helpers
{
    public class AsyncHelper
    {
        public static async Task<TResult> ToAsync<TResult, TArgs>(TArgs args, Func<TArgs, TResult> syncCallback)
            where TResult : class
            where TArgs : EventArgs
        {
            return await Task.Run<TResult>(() => { return syncCallback(args); });
        }
    }
}
