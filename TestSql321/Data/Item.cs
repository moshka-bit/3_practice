using System;
using System.Collections.Generic;

namespace TestSql321.Data;

public partial class Item
{
    public int ItemId { get; set; }

    public string? ItemName { get; set; }

    public int? ItemPrice { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<Busket> Buskets { get; set; } = new List<Busket>();
}
