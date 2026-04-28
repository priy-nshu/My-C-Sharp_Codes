using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace HttpTriggers.Models;

public partial class BykeStoresContext : DbContext
{
    //public string _ConStr;
    //public BykeStoresContext()
    //{
    //}
    //public BykeStoresContext(string ConStr)
    //{
    //    _ConStr = ConStr;
    //}
    public BykeStoresContext(DbContextOptions<BykeStoresContext> options)
        : base(options)
    {
    }


    public virtual DbSet<Staff> Staffs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
            optionsBuilder.UseSqlServer("server=EC2AMAZ-EHR6SVV; Database=BykeStores; Integrated Security=True; Trusted_Connection=True ;TrustServerCertificate=True;");
            //optionsBuilder.UseSqlServer(_ConStr);
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
       
        modelBuilder.Entity<Staff>(entity =>
        {
            entity.HasKey(e => e.StaffId).HasName("PK__staffs__1963DD9C039863AF");

            entity.ToTable("staffs", "SALES");

            entity.HasIndex(e => e.Email, "UQ__staffs__AB6E6164A8FF2CC8").IsUnique();

            entity.Property(e => e.StaffId).HasColumnName("staff_id");
            entity.Property(e => e.Active).HasColumnName("active");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("last_name");
            entity.Property(e => e.ManagerId).HasColumnName("manager_id");
            entity.Property(e => e.Phone)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("phone");
            entity.Property(e => e.StoreId).HasColumnName("store_id");
        });
       
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
