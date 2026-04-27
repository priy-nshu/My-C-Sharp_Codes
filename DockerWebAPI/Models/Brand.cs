using System;
using System.Collections.Generic;

namespace DockerWebAPI.Models;

public partial class Brand
{
    public int BrandId { get; set; }

    public string BrandName { get; set; } = null!;

}
