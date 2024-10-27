namespace Framework.App.Model
{
    /// <summary>======================================================================
    /// Namespace: Framework.App.Model
    ///  Filename: Triple.cs
    /// Developer: Billkrat
    ///   Created: 2024.10.27
    ///   Purpose: A variation of a RDF Triple - added Id and Value fields
    ///            https://www.w3.org/TR/rdf11-primer/#section-triple
    ///            
    /// Author		Date	Comments
    /// ----------- ------- ----------------------------------------------------------
    /// 
    /// =====================================================================</summary>
    public class Triple
    {
        public Guid Id { get; set; }
        public string? Subject { get; set; }
        public string? Predicate { get; set; }
        public string? Object { get; set; }
        public string? Value { get; set; }

    }
}
