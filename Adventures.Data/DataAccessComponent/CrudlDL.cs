using Adventures.Data.Interfaces;
using Adventures.Framework.Events;
using Adventures.Framework.Interfaces;
using Adventures.Framework.Results;

namespace Adventures.Data.DataAccessComponent
{
    public class CrudlDL(ITripleStoreContext context) : ICrudlDL
    {
        public CrudlResult GetData(object sender, CrudlEventArgs e)
        {
            var results = context.RdfTriples.ToList();
            return new CrudlResult(results);
        }
    }
}
