using Framework.App.Model;
using Framework.Shared.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace blogapi.Context
{
    /// <summary>
    /// Init: https://learn.microsoft.com/en-us/ef/core/get-started/overview/first-app?tabs=netcore-cli
    /// Update: https://learn.microsoft.com/en-us/ef/core/managing-schemas/migrations/applying?tabs=dotnet-core-cli
    /// </summary>
    public class BloggingContext : DbContext, IBloggingContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Triple> Triples { get; set; }

        public string DbPath { get; }

        public BloggingContext()
        {
            var path = $"{Environment.CurrentDirectory}\\App_Data\\";
            DbPath = Path.Join(path, "blogging.db");
        }

        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");
    }
}
/*
 
dotnet tool install --global dotnet-ef
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet ef migrations add InitialCreate
dotnet ef database update
 
 */
