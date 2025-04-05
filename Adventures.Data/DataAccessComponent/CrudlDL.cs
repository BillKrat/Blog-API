using Adventures.Data.Interfaces;
using Adventures.Framework.Events;
using Adventures.Framework.Interfaces;
using Adventures.Framework.Results;
using Adventures.Model.Events;
using Adventures.Model.Extensions;

namespace Adventures.Data.DataAccessComponent
{
    public class CrudlDL(ITripleStoreContext context) : ICrudlDL
    {
        public CrudlResult GetData(object sender, CrudlEventArgs e)
        {
            RdfCrudlEventArgs? args = e.DownCast();
            if (args == null) throw new ArgumentNullException(nameof(e));

            var subject= args?.Subject ?? "[null]";
            var predicate = args?.Predicate ?? "[null]";

            var results = context.RdfTriples
                .Where(rt=> rt.Subject == subject
                         && rt.Predicate == predicate)
                .ToList();

            return new CrudlResult(results);
        }
    }
}
