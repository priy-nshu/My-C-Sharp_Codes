using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace OrdersWebAPI.Models;

public partial class OrderDBContext : DbContext
{
    public string _ConStr;
    public OrderDBContext()
    {
    }
    public OrderDBContext(string ConStr)
    {
        _ConStr = ConStr;
    }
    public OrderDBContext(DbContextOptions<OrderDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderItem> OrderItems { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
            //optionsBuilder.UseSqlServer("server=EC2AMAZ-EHR6SVV; Database=BykeStores; Integrated Security=True; Trusted_Connection=True ;TrustServerCertificate=True;");
            optionsBuilder.UseSqlServer(_ConStr);
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
       

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__orders__46596229D0BB174E");

            entity.ToTable("orders", "SALES");

            entity.Property(e => e.OrderId).HasColumnName("order_id");
            entity.Property(e => e.CustomerId).HasColumnName("customer_id");
            entity.Property(e => e.OrderDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("order_date");
            entity.Property(e => e.OrderStatus).HasColumnName("order_status");
            entity.Property(e => e.RequiredDate).HasColumnName("required_date");
            entity.Property(e => e.ShippedDate).HasColumnName("shipped_date");
            entity.Property(e => e.StaffId).HasColumnName("staff_id");
            entity.Property(e => e.StoreId).HasColumnName("store_id");

            //entity.HasOne(d => d.Customer).WithMany(p => p.Orders)
            //    .HasForeignKey(d => d.CustomerId)
            //    .OnDelete(DeleteBehavior.Cascade)
            //    .HasConstraintName("FK__orders__customer__5BE2A6F2");

            //entity.HasOne(d => d.Staff).WithMany(p => p.Orders)
            //    .HasForeignKey(d => d.StaffId)
            //    .OnDelete(DeleteBehavior.ClientSetNull)
            //    .HasConstraintName("FK__orders__staff_id__5DCAEF64");

            //entity.HasOne(d => d.Store).WithMany(p => p.Orders)
            //    .HasForeignKey(d => d.StoreId)
            //    .HasConstraintName("FK__orders__store_id__5CD6CB2B");
        });

        modelBuilder.Entity<OrderItem>(entity =>
        {
            entity.HasKey(e => new { e.OrderId, e.ItemId }).HasName("PK__order_it__837942D479E34F2F");

            entity.ToTable("order_items", "SALES");

            entity.Property(e => e.OrderId).HasColumnName("order_id");
            entity.Property(e => e.ItemId).HasColumnName("item_id");
            entity.Property(e => e.Discount)
                .HasColumnType("decimal(4, 2)")
                .HasColumnName("discount");
            entity.Property(e => e.ListPrice)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("list_price");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.Quantity).HasColumnName("quantity");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK__order_ite__order__619B8048");

            //entity.HasOne(d => d.Product).WithMany(p => p.OrderItems)
            //    .HasForeignKey(d => d.ProductId)
            //    .HasConstraintName("FK__order_ite__produ__628FA481");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
