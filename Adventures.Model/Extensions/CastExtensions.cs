using Adventures.Framework.Results;
using Adventures.Model.Results;

namespace Adventures.Model.Extensions
{
    public static class CastExtensions
    {
        public static RdfTripleResults? DownCast(this CrudlResult? results)
        {
            return (RdfTripleResults?)results;
        }
    }
}
