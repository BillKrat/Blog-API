using Framework.App.Model;
using Framework.Shared.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace blogapi.Context
{
    /// <summary>======================================================================
    /// Namespace: BlogApi
    ///  Filename: BloggingContext.cs
    /// Developer: Billkrat
    ///   Created: 2024.10.27
    ///   Purpose: EF Context for the blogging application
    ///      Init: https://learn.microsoft.com/en-us/ef/core/get-started/overview/first-app?tabs=netcore-cli
    ///    Update: https://learn.microsoft.com/en-us/ef/core/managing-schemas/migrations/applying?tabs=dotnet-core-cli
    ///
    /// Author		Date	Comments
    /// ----------- ------- ----------------------------------------------------------
    /// 
    /// =====================================================================</summary>
    public class BloggingContext : DbContext, IBloggingContext
    {
        /// <summary>
        /// Blogs table
        /// </summary>
        public DbSet<Blog> Blogs { get; set; }
        /// <summary>
        /// Posts table
        /// </summary>
        public DbSet<Post> Posts { get; set; }
        /// <summary>
        /// Tripes table
        /// </summary>
        public DbSet<Triple> Triples { get; set; }

        /// <summary>
        /// Path to blogging.db
        /// </summary>
        public string DbPath { get; }

        /// <summary>
        /// Constructor configures path blogging.db
        /// </summary>
        public BloggingContext()
        {
            var path = $"{Environment.CurrentDirectory}\\App_Data\\";
            DbPath = Path.Join(path, "blogging.db");
        }

        /// <summary>
        /// The following configures EF to create a Sqlite database file in the
        /// special "local" folder for your platform.
        /// </summary>
        /// <param name="options"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");
    }
}
/*  The following will initialize the database
 
dotnet tool install --global dotnet-ef
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet ef migrations add InitialCreate
dotnet ef database update
 
 */
