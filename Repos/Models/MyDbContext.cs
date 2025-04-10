using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Repos.Models;

public partial class MyDbContext : DbContext
{
    public MyDbContext()
    {
    }

    public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Review> Reviews { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<ProductCategoryView> ProductCategoryViews { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=TestProject;Trusted_Connection=True;TrustServerCertificate=True;");


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //modelBuilder.Entity<Category>(entity =>
        //{
        //    entity.HasKey(e => e.Id).HasName("PK__Category__3213E83F20C48972");

        //    entity.ToTable("Category");

        //    entity.Property(e => e.Id).HasColumnName("id");
        //    entity.Property(e => e.Name)
        //        .HasMaxLength(50)
        //        .HasColumnName("name");
        //});

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Category");
            entity.Property(e => e.Name).HasMaxLength(50).IsRequired();
        });

        //modelBuilder.Entity<Order>(entity =>
        //{
        //    entity.HasKey(e => e.Id).HasName("PK__Orders__3213E83FAD21658F");

        //    entity.Property(e => e.Id).HasColumnName("id");
        //    entity.Property(e => e.IdProduct).HasColumnName("id_product");
        //    entity.Property(e => e.IdUser).HasColumnName("id_user");

        //    entity.HasOne(d => d.IdProductNavigation).WithMany(p => p.Orders)
        //        .HasForeignKey(d => d.IdProduct)
        //        .HasConstraintName("FK__Orders__id_produ__5070F446");

        //    entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Orders)
        //        .HasForeignKey(d => d.IdUser)
        //        .HasConstraintName("FK__Orders__id_user__4F7CD00D");
        //});

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Order");
            entity.HasOne(e => e.IdProductNavigation)
                .WithMany(p => p.Orders)
                .HasForeignKey(e => e.IdProduct);
            entity.HasOne(e => e.IdUserNavigation)
                .WithMany(u => u.Orders)
                .HasForeignKey(e => e.IdUser);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Product__3213E83FB99344FD");

            entity.ToTable("Product");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdCategory).HasColumnName("id_category");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.PriceDelivery).HasColumnName("price_delivery");
            entity.Property(e => e.Quantity).HasColumnName("quantity");

            entity.HasOne(d => d.IdCategoryNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.IdCategory)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Product__id_cate__3B75D760");

            entity.HasMany(d => d.IdReviews).WithMany(p => p.IdProducts)
                .UsingEntity<Dictionary<string, object>>(
                    "ProductReview",
                    r => r.HasOne<Review>().WithMany()
                        .HasForeignKey("IdReview")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__ProductRe__id_re__3F466844"),
                    l => l.HasOne<Product>().WithMany()
                        .HasForeignKey("IdProduct")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__ProductRe__id_pr__3E52440B"),
                    j =>
                    {
                        j.HasKey("IdProduct", "IdReview").HasName("PK__ProductR__D8CE77C3C540E4E9");
                        j.ToTable("ProductReviews");
                        j.IndexerProperty<int>("IdProduct").HasColumnName("id_product");
                        j.IndexerProperty<int>("IdReview").HasColumnName("id_review");
                    });
        });

        modelBuilder.Entity<Review>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Review");
            entity.Property(e => e.Text).HasMaxLength(4000);
            entity.HasMany(e => e.IdProducts)
                .WithMany(p => p.IdReviews)
                .UsingEntity(j => j.ToTable("ProductReviews"));
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_User");
            entity.Property(e => e.Name).HasMaxLength(50).IsRequired();
            entity.Property(e => e.Age).IsRequired();
        });

        modelBuilder.Entity<ProductCategoryView>(entity =>
        {
            entity.HasNoKey();
            entity.ToView("ProductCategoryView");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.product_name).HasColumnName("product_name");
            entity.Property(e => e.category_name).HasColumnName("category_name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
