using Framework.Shared.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace blogapi.Context;

/// <summary>
/// 
/// </summary>
public partial class BloggingContext : DbContext, IBloggingContext
{
    /// <summary>
    /// 
    /// </summary>
    public string? CurrentDal { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public BloggingContext()
    {
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="options"></param>
    public BloggingContext(DbContextOptions<BloggingContext> options) : base(options)
    {
    }

    /// <summary>
    /// 
    /// </summary>
    public virtual DbSet<Triple> Triples { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public virtual DbSet<TriplesCrossRef> TriplesCrossRefs { get; set; }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="optionsBuilder"></param>
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // The only way IsConfigured will be false is if the BloggingContext options are
        // not set in ServicesExtensions, i.e., UseSqlServer was not invoked because the
        // setting isUsingSqlServer is not set or is set to false - defaulting to SqlLite
        if (!optionsBuilder.IsConfigured)
        {
            var path = $"{Environment.CurrentDirectory}\\App_Data\\";
            var connectionString = Path.Join(path, "blogging.db");
            optionsBuilder.UseSqlite($"Data Source={connectionString}");
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="modelBuilder"></param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Triple>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Triples_Id");

            entity.HasIndex(e => new { e.Subject, e.Predicate, e.Object }, "IX_TriplesSubPredObj").IsUnique();

            entity.HasIndex(e => e.Object, "IX_Triples_Object");

            entity.HasIndex(e => e.Predicate, "IX_Triples_Predicate");

            entity.HasIndex(e => e.Subject, "IX_Triples_Subject");

            entity.Property(e => e.Object)
                .HasMaxLength(254)
                .IsUnicode(false);
            entity.Property(e => e.Predicate)
                .HasMaxLength(254)
                .IsUnicode(false);
            entity.Property(e => e.Subject)
                .HasMaxLength(254)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TriplesCrossRef>(entity =>
        {
            entity.ToTable("TriplesCrossRef");

            entity.HasIndex(e => e.ChildId, "IX_TriplesCrossRef_ChildId");

            entity.HasIndex(e => e.ParentId, "IX_TriplesCrossRef_ParentId");

            entity.HasIndex(e => e.TripleId, "IX_TriplesCrossRef_TripleId");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);



    /*  
        -- SQL SERVER: The following was used to generate the above context from an existing database / tables
        Scaffold-DbContext "Data Source=SQL.site.net;User ID=dbadmin;Password=1234;Initial Catalog=dbmain;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Context -Tables Triples, TriplesCrossRef -Context BloggingContext

        -- SQL LITE: The following will initialize the database
        dotnet tool install --global dotnet-ef
        dotnet add package Microsoft.EntityFrameworkCore.Design
        dotnet ef migrations add InitialCreate
        dotnet ef database update

 */
}
