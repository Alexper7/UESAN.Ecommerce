using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace UESAN.Ecommerce.CORE.Infrastructure.Data;

public partial class StoreDbContext : DbContext
{
    public StoreDbContext()
    {
    }

    public StoreDbContext(DbContextOptions<StoreDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cajas> Cajas { get; set; }

    public virtual DbSet<Category> Category { get; set; }

    public virtual DbSet<Conductor> Conductor { get; set; }

    public virtual DbSet<Coordinador> Coordinador { get; set; }

    public virtual DbSet<Envio> Envio { get; set; }

    public virtual DbSet<Favorite> Favorite { get; set; }

    public virtual DbSet<Movil> Movil { get; set; }

    public virtual DbSet<OrderDetail> OrderDetail { get; set; }

    public virtual DbSet<Orders> Orders { get; set; }

    public virtual DbSet<Payment> Payment { get; set; }

    public virtual DbSet<Product> Product { get; set; }

    public virtual DbSet<ProductDetail> ProductDetail { get; set; }

    public virtual DbSet<User> User { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LAPTOP-1QSGALC3\\SQLEXPRESS;Database=StoreDB;Integrated Security=true;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cajas>(entity =>
        {
            entity.HasKey(e => e.CajasCod).HasName("PK__CAJAS__22B783821ECF812E");

            entity.ToTable("CAJAS");

            entity.Property(e => e.CajasCod)
                .ValueGeneratedNever()
                .HasColumnName("cajas_cod");
            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.FechaFfFv).HasColumnName("fecha_FF_FV");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.Property(e => e.Description).HasMaxLength(100);
        });

        modelBuilder.Entity<Conductor>(entity =>
        {
            entity.HasKey(e => e.ConductorId).HasName("PK__CONDUCTO__A16B14C838EC7CA3");

            entity.ToTable("CONDUCTOR");

            entity.Property(e => e.ConductorId)
                .ValueGeneratedNever()
                .HasColumnName("conductor_id");
            entity.Property(e => e.Direccion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("direccion");
            entity.Property(e => e.FechaNacimiento).HasColumnName("fecha_nacimiento");
            entity.Property(e => e.Nombre)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Telefono)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("telefono");
        });

        modelBuilder.Entity<Coordinador>(entity =>
        {
            entity.HasKey(e => e.CoordinadorId).HasName("PK__COORDINA__26EDBF76580E965E");

            entity.ToTable("COORDINADOR");

            entity.Property(e => e.CoordinadorId)
                .ValueGeneratedNever()
                .HasColumnName("coordinador_id");
            entity.Property(e => e.FechaNacimiento).HasColumnName("fecha_nacimiento");
            entity.Property(e => e.Firma)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("firma");
            entity.Property(e => e.Nombre)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Envio>(entity =>
        {
            entity.HasKey(e => e.EnvioCod).HasName("PK__ENVIO__1B1D478BF6A6FB04");

            entity.ToTable("ENVIO");

            entity.Property(e => e.EnvioCod)
                .ValueGeneratedNever()
                .HasColumnName("envio_cod");
            entity.Property(e => e.Novedad)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("novedad");
        });

        modelBuilder.Entity<Favorite>(entity =>
        {
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");

            entity.HasOne(d => d.Product).WithMany(p => p.Favorite)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK_Favorite_Product");

            entity.HasOne(d => d.User).WithMany(p => p.Favorite)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_Favorite_User");
        });

        modelBuilder.Entity<Movil>(entity =>
        {
            entity.HasKey(e => e.MovilId).HasName("PK__MOVIL__6D1B41742A94FA4F");

            entity.ToTable("MOVIL");

            entity.Property(e => e.MovilId)
                .ValueGeneratedNever()
                .HasColumnName("movil_id");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.Marca)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("marca");
            entity.Property(e => e.Placa)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("placa");
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Orders).WithMany(p => p.OrderDetail)
                .HasForeignKey(d => d.OrdersId)
                .HasConstraintName("FK_OrderDetail_Orders");

            entity.HasOne(d => d.Product).WithMany(p => p.OrderDetail)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK_OrderDetail_Product");
        });

        modelBuilder.Entity<Orders>(entity =>
        {
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.Status)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.TotalAmount).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.User).WithMany(p => p.Orders)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_Orders_User");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.Property(e => e.PaymentMethod)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Status)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.TotalAmount).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Orders).WithMany(p => p.Payment)
                .HasForeignKey(d => d.OrdersId)
                .HasConstraintName("FK_Payment_Orders");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.Property(e => e.Description).HasMaxLength(100);
            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Category).WithMany(p => p.Product)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK_Product_Category");
        });

        modelBuilder.Entity<ProductDetail>(entity =>
        {
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductDetail)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK_ProductDetail_Product");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.Address).HasMaxLength(100);
            entity.Property(e => e.Country).HasMaxLength(50);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(100);
            entity.Property(e => e.Type)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
