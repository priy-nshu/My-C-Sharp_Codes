using System;
using System.Collections.Generic;

namespace BykeStoreDBFirst.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public int? CustomerId { get; set; }

    public byte OrderStatus { get; set; }

    public DateOnly OrderDate { get; set; }

    public DateOnly RequiredDate { get; set; }

    public DateOnly? ShippedDate { get; set; }

    public int StoreId { get; set; }

    public int StaffId { get; set; }

    public virtual Customer? Customer { get; set; }//FK

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual Staff Staff { get; set; } = null!; //Foriegn Keys

    public virtual Store Store { get; set; } = null!;
}
