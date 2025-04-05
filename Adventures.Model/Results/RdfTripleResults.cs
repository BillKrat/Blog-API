using Adventures.Framework.Results;
using Adventures.Model.Models;

namespace Adventures.Model.Results
{
    public class RdfTripleResults : CrudlResult
    {
        public new List<RdfTriple>? Data { get { return base.Data as List<RdfTriple>; } }
        public RdfTripleResults(CrudlResult result)
        {
            base.Data = result.Data;
        }
    }
}
