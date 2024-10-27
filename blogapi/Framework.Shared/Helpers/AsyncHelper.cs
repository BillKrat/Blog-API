namespace Framework.Shared.Helpers
{
    /// <summary>======================================================================
    /// Namespace: Framework.Shared
    ///  Filename: AsyncHelper.cs
    /// Developer: Billkrat
    ///   Created: 2024.10.27
    ///   Purpose: Helper for async/sync functions
    ///
    /// Author		Date	Comments
    /// ----------- ------- ----------------------------------------------------------
    ///  
    /// =====================================================================</summary>
    public class AsyncHelper
    {
        public static async Task<TResult> ToAsync<TResult, TArgs>(
            TArgs args, Func<TArgs, TResult> syncCallback)
                where TResult : class
                where TArgs : EventArgs
        {
            return await Task.Run<TResult>(() => { return syncCallback(args); });
        }
    }
}
