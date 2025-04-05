using Adventures.Framework.Events;

namespace Adventures.Model.Events
{
    public class RdfCrudlEventArgs : CrudlEventArgs
    {
        public string? Id { get; set; }  
        public string? Subject { get; set; } 
        public string? Predicate { get; set; }
        public string? Tag { get; set; }

    }
}
