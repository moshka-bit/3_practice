using System;
using System.Collections.Generic;

namespace TestSql321.Data;

public partial class Busket
{
    public int BusketId { get; set; }

    public int UserId { get; set; }

    public int ItemId { get; set; }

    public int? Count { get; set; }

    public virtual Item Item { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
