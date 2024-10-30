using System;
using System.Collections.Generic;

namespace blogapi.Context;

public partial class TriplesCrossRef
{
    public int Id { get; set; }

    public int TripleId { get; set; }

    public int? ChildId { get; set; }

    public int? ParentId { get; set; }
}
