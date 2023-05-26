using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ClothWebApplication.Models;

public partial class InventoryContext : DbContext
{
    public InventoryContext()
    {
    }

    public InventoryContext(DbContextOptions<InventoryContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Brand> Brands { get; set; }

    public virtual DbSet<Cloth> Clothes { get; set; }

    public virtual DbSet<MigrationHistory> MigrationHistories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=MSI\\SQLEXPRESS;Database=Inventory;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Brand>(entity =>
        {
            entity.HasKey(e => e.BrandId).HasName("PK_dbo.Brands");

            entity.Property(e => e.BrandId).HasColumnName("brandId");
            entity.Property(e => e.BrandName).HasColumnName("_brandName");
            entity.Property(e => e.Country).HasColumnName("_country");
            entity.Property(e => e.Logo).HasColumnName("_logo");
        });

        modelBuilder.Entity<Cloth>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.Clothes");

            entity.HasIndex(e => e.BrandBrandId, "IX__brand_brandId");

            entity.Property(e => e.Id).HasColumnName("_id");
            entity.Property(e => e.BrandBrandId).HasColumnName("_brand_brandId");
            entity.Property(e => e.Color).HasColumnName("_color");
            entity.Property(e => e.Discriminator).HasMaxLength(128);
            entity.Property(e => e.Fabric).HasColumnName("_fabric");
            entity.Property(e => e.HasHood).HasColumnName("_hasHood");
            entity.Property(e => e.Image).HasColumnName("_image");
            entity.Property(e => e.Inventory).HasColumnName("_inventory");
            entity.Property(e => e.JacketSize).HasColumnName("_jacketSize");
            entity.Property(e => e.PantsSize).HasColumnName("_pantsSize");
            entity.Property(e => e.Price).HasColumnName("_price");
            entity.Property(e => e.TshirtSize).HasColumnName("_tshirtSize");
            entity.Property(e => e.WaistSize).HasColumnName("_waistSize");

            entity.HasOne(d => d.BrandBrand).WithMany(p => p.Clothes)
                .HasForeignKey(d => d.BrandBrandId)
                .HasConstraintName("FK_dbo.Clothes_dbo.Brands__brand_brandId");
        });

        modelBuilder.Entity<MigrationHistory>(entity =>
        {
            entity.HasKey(e => new { e.MigrationId, e.ContextKey }).HasName("PK_dbo.__MigrationHistory");

            entity.ToTable("__MigrationHistory");

            entity.Property(e => e.MigrationId).HasMaxLength(150);
            entity.Property(e => e.ContextKey).HasMaxLength(300);
            entity.Property(e => e.ProductVersion).HasMaxLength(32);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
