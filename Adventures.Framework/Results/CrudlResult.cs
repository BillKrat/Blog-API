namespace Adventures.Framework.Results
{
    public class CrudlResult
    {
        public object? Data { get; set; }

        public CrudlResult() { }

        public CrudlResult(object results)
        {
            Data = results;
        }


    }
}
