using Adventures.Framework.Events;
using Adventures.Framework.Results;
using Adventures.Model.Events;
using Adventures.Model.Results;

namespace Adventures.Model.Extensions
{
    public static class CastExtensions
    {
        public static RdfTripleResults? DownCast(this CrudlResult? results)
        {
            return (RdfTripleResults?)results;
        }
        public static RdfCrudlEventArgs? DownCast(this CrudlEventArgs? results)
        {
            return (RdfCrudlEventArgs?)results;
        }

    }
}
