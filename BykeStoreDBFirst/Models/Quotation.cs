using System;
using System.Collections.Generic;

namespace BykeStoreDBFirst.Models;

public partial class Quotation
{
    public int QuotationNo { get; set; }

    public DateOnly ValidFrom { get; set; }

    public DateOnly ValidTo { get; set; }

    public string Description { get; set; } = null!;

    public decimal Amount { get; set; }

    public string? CustomerName { get; set; }
}
