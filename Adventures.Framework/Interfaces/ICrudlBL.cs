using Adventures.Framework.Events;
using Adventures.Framework.Results;

namespace Adventures.Framework.Interfaces
{
    public interface ICrudlBL
    {
        CrudlResult GetData(object sender, CrudlEventArgs e);
    }
}
