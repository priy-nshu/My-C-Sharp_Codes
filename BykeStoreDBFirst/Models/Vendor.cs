using System;
using System.Collections.Generic;

namespace BykeStoreDBFirst.Models;

public partial class Vendor
{
    public int VendorId { get; set; }

    public string VendorName { get; set; } = null!;

    public int GroupId { get; set; }

    public virtual VendorGroup Group { get; set; } = null!;
}
