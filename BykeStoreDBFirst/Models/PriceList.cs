using System;
using System.Collections.Generic;

namespace BykeStoreDBFirst.Models;

public partial class PriceList
{
    public int ProductId { get; set; }

    public DateOnly ValidFrom { get; set; }

    public decimal Price { get; set; }

    public decimal Discount { get; set; }

    public decimal Surcharge { get; set; }

    public string? Note { get; set; }
}
