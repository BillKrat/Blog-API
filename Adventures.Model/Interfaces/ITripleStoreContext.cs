using Adventures.Model.Models;
using Microsoft.EntityFrameworkCore;

namespace Adventures.Data.Interfaces
{
    public interface ITripleStoreContext
    {
        DbSet<RdfTriple> RdfTriples { get; set; }
        DbSet<VShortGuid> VShortGuids { get; set; }
    }
}