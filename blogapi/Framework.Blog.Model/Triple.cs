using System;
using System.Collections.Generic;

namespace blogapi.Context;

public partial class Triple
{
    public int Id { get; set; }

    public string? Subject { get; set; }

    public string? Predicate { get; set; }

    public string? Object { get; set; }

    public byte[]? Value { get; set; }
}
