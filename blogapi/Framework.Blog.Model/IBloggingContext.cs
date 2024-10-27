using Framework.App.Model;
using Microsoft.EntityFrameworkCore;

namespace Framework.Shared.Interfaces
{
    public interface IBloggingContext
    {
        DbSet<Blog> Blogs { get; set; }
        string DbPath { get; }
        DbSet<Post> Posts { get; set; }
        DbSet<Triple> Triples { get; set; }
    }
}