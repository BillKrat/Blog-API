namespace Framework.App.Model
{
    /// <summary>======================================================================
    /// Namespace: Framework.App.Model
    ///  Filename: Blog.cs
    /// Developer: Billkrat
    ///   Created: 2024.10.27
    ///   Purpose: Blog Model
    ///
    /// Author		Date	Comments
    /// ----------- ------- ----------------------------------------------------------
    ///  
    /// =====================================================================</summary>
    public class Blog
    {
        public int BlogId { get; set; }
        public required string Url { get; set; }

        public List<Post> Posts { get; } = new();
    }
}
