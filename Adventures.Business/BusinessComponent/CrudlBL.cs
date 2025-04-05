using Adventures.Framework.Events;
using Adventures.Framework.Interfaces;
using Adventures.Framework.Results;
using Adventures.Model.Results;

namespace Adventures.Business.BusinessComponent
{
    public class CrudlBL(ICrudlDL crudDl) : ICrudlBL
    {
        public CrudlResult GetData(object sender, CrudlEventArgs e)
        {
            var results = new RdfTripleResults(crudDl.GetData(sender, e));
            return new RdfTripleResults(results);
        }

    }
}
