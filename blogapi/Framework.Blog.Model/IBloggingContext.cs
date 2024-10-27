using Framework.App.Model;
using Microsoft.EntityFrameworkCore;

namespace Framework.Shared.Interfaces
{
    /// <summary>======================================================================
    ///  Filename: IBloggingContext.cs
    /// Namespace: Framework.App.Model
    /// Developer: Billkrat
    ///   Created: 2024.10.27
    ///   Purpose: Interface for BloggingContext
    ///
    /// Author		Date	Comments
    /// ----------- ------- ----------------------------------------------------------
    ///  
    /// =====================================================================</summary>
    public interface IBloggingContext
    {
        DbSet<Blog> Blogs { get; set; }
        string DbPath { get; }
        DbSet<Post> Posts { get; set; }
        DbSet<Triple> Triples { get; set; }
    }
}