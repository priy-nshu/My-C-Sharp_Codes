using System;
using System.Collections.Generic;

namespace BykeStoreDBFirst.Models;

public partial class VendorGroup
{
    public int GroupId { get; set; }

    public string GroupName { get; set; } = null!;

    public virtual ICollection<Vendor> Vendors { get; set; } = new List<Vendor>();
}
