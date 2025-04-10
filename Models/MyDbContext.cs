﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Database_first.Models;

public partial class MyDbContext : DbContext
{
    public MyDbContext()
    {
    }

    public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Delivery> Deliveries { get; set; }

    public virtual DbSet<Discount> Discounts { get; set; }

    public virtual DbSet<Measurement> Measurements { get; set; }

    public virtual DbSet<Producer> Producers { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Region> Regions { get; set; }

    public virtual DbSet<Sale> Sales { get; set; }

    public virtual DbSet<Supplier> Suppliers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=Store;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Address>(entity =>
        {
            entity.ToTable("Address");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdCity).HasColumnName("id_city");
            entity.Property(e => e.Street)
                .HasMaxLength(50)
                .HasColumnName("street");

            entity.HasOne(d => d.IdCityNavigation).WithMany(p => p.Addresses)
                .HasForeignKey(d => d.IdCity)
                .HasConstraintName("FK_Address_City");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.ToTable("Category");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<City>(entity =>
        {
            entity.ToTable("City");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdRegion).HasColumnName("id_region");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");

            entity.HasOne(d => d.IdRegionNavigation).WithMany(p => p.Cities)
                .HasForeignKey(d => d.IdRegion)
                .HasConstraintName("FK_City_Region");
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.ToTable("Country");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Delivery>(entity =>
        {
            entity.ToTable("Delivery");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DateOfDelivery).HasColumnName("date_of_delivery");
            entity.Property(e => e.IdProduct).HasColumnName("id_product");
            entity.Property(e => e.IdSupplier).HasColumnName("id_supplier");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.Quantity).HasColumnName("quantity");

            entity.HasOne(d => d.IdProductNavigation).WithMany(p => p.Deliveries)
                .HasForeignKey(d => d.IdProduct)
                .HasConstraintName("FK_Delivery_Product");

            entity.HasOne(d => d.IdSupplierNavigation).WithMany(p => p.Deliveries)
                .HasForeignKey(d => d.IdSupplier)
                .HasConstraintName("FK_Delivery_Supplier");
        });

        modelBuilder.Entity<Discount>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Markup");

            entity.ToTable("Discount");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Percent).HasColumnName("percent");
        });

        modelBuilder.Entity<Measurement>(entity =>
        {
            entity.ToTable("Measurement");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Producer>(entity =>
        {
            entity.ToTable("Producer");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdAddress).HasColumnName("id_address");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");

            entity.HasOne(d => d.IdAddressNavigation).WithMany(p => p.Producers)
                .HasForeignKey(d => d.IdAddress)
                .HasConstraintName("FK_Producer_Address");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.ToTable("Product");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdCategory).HasColumnName("id_category");
            entity.Property(e => e.IdMarkup).HasColumnName("id_markup");
            entity.Property(e => e.IdMeasurement).HasColumnName("id_measurement");
            entity.Property(e => e.IdProducer).HasColumnName("id_producer");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.Quantity).HasColumnName("quantity");

            entity.HasOne(d => d.IdCategoryNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.IdCategory)
                .HasConstraintName("FK_Product_Category");

            entity.HasOne(d => d.IdMarkupNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.IdMarkup)
                .HasConstraintName("FK_Product_Markup");

            entity.HasOne(d => d.IdMeasurementNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.IdMeasurement)
                .HasConstraintName("FK_Product_Measurement");

            entity.HasOne(d => d.IdProducerNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.IdProducer)
                .HasConstraintName("FK_Product_Producer");
        });

        modelBuilder.Entity<Region>(entity =>
        {
            entity.ToTable("Region");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdCountry).HasColumnName("id_country");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");

            entity.HasOne(d => d.IdCountryNavigation).WithMany(p => p.Regions)
                .HasForeignKey(d => d.IdCountry)
                .HasConstraintName("FK_Region_Country");
        });

        modelBuilder.Entity<Sale>(entity =>
        {
            entity.ToTable("Sale");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DateOfSale).HasColumnName("date_of_sale");
            entity.Property(e => e.IdProduct).HasColumnName("id_product");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.Quantity).HasColumnName("quantity");

            entity.HasOne(d => d.IdProductNavigation).WithMany(p => p.Sales)
                .HasForeignKey(d => d.IdProduct)
                .HasConstraintName("FK_Sale_Product");
        });

        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.ToTable("Supplier");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdAddress).HasColumnName("id_address");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");

            entity.HasOne(d => d.IdAddressNavigation).WithMany(p => p.Suppliers)
                .HasForeignKey(d => d.IdAddress)
                .HasConstraintName("FK_Supplier_Address");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
