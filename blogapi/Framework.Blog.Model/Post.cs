namespace Framework.App.Model
{
    /// <summary>======================================================================
    /// Namespace: Framework.App.Model
    ///  Filename: Post.cs
    /// Developer: Billkrat
    ///   Created: 2024.10.27
    ///   Purpose: Blog Post model
    ///
    /// Author		Date	Comments
    /// ----------- ------- ----------------------------------------------------------
    ///  
    /// =====================================================================</summary>
    public class Post
    {
        public int PostId { get; set; }
        public required string Title { get; set; }
        public required string Content { get; set; }

        public int BlogId { get; set; }
        public required Blog Blog { get; set; }
    }
}
