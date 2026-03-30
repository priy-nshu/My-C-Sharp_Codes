using System;
using System.Collections.Generic;

namespace BykeStoreDBFirst.Models;

public partial class Office
{
    public int OfficeId1 { get; set; }

    public int OfficeId2 { get; set; }

    public string OfficeName { get; set; } = null!;

    public string OfficeAddress { get; set; } = null!;

    public string? Phone { get; set; }

    public int HqId { get; set; }

    public int BranchId { get; set; }
}
