﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using dotAshFashionNexus.Persistence.Data;

#nullable disable

namespace dotAshFashionNexus.Persistence.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("dotAshFashionNexus.Persistence.Models.Product", b =>
                {
                    b.Property<int>("ProductID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ProductID"));

                    b.Property<DateTimeOffset>("CreatedDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("CreatedOn");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("SearchEngineFriendlyName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("SearchEngineFriendlyName");

                    b.HasKey("ProductID");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductID = 1,
                            CreatedDate = new DateTimeOffset(new DateTime(2024, 5, 11, 17, 2, 19, 853, DateTimeKind.Unspecified).AddTicks(2091), new TimeSpan(0, 0, 0, 0, 0)),
                            Name = "T-Shirt",
                            SearchEngineFriendlyName = "t-shirt"
                        },
                        new
                        {
                            ProductID = 2,
                            CreatedDate = new DateTimeOffset(new DateTime(2024, 5, 11, 17, 2, 19, 853, DateTimeKind.Unspecified).AddTicks(2103), new TimeSpan(0, 0, 0, 0, 0)),
                            Name = "Jeans",
                            SearchEngineFriendlyName = "jeans"
                        },
                        new
                        {
                            ProductID = 3,
                            CreatedDate = new DateTimeOffset(new DateTime(2024, 5, 11, 17, 2, 19, 853, DateTimeKind.Unspecified).AddTicks(2105), new TimeSpan(0, 0, 0, 0, 0)),
                            Name = "Sweater",
                            SearchEngineFriendlyName = "sweater"
                        },
                        new
                        {
                            ProductID = 4,
                            CreatedDate = new DateTimeOffset(new DateTime(2024, 5, 11, 17, 2, 19, 853, DateTimeKind.Unspecified).AddTicks(2107), new TimeSpan(0, 0, 0, 0, 0)),
                            Name = "Dress",
                            SearchEngineFriendlyName = "dress"
                        },
                        new
                        {
                            ProductID = 5,
                            CreatedDate = new DateTimeOffset(new DateTime(2024, 5, 11, 17, 2, 19, 853, DateTimeKind.Unspecified).AddTicks(2109), new TimeSpan(0, 0, 0, 0, 0)),
                            Name = "Shoes",
                            SearchEngineFriendlyName = "shoes"
                        });
                });

            modelBuilder.Entity("dotAshFashionNexus.Persistence.Models.Stock", b =>
                {
                    b.Property<int>("StockID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("StockID"));

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.Property<int>("VariantID")
                        .HasColumnType("integer");

                    b.Property<int>("WarehouseID")
                        .HasColumnType("integer");

                    b.HasKey("StockID");

                    b.HasIndex("VariantID");

                    b.HasIndex("WarehouseID");

                    b.ToTable("Stocks");

                    b.HasData(
                        new
                        {
                            StockID = 1,
                            Quantity = 10,
                            VariantID = 1,
                            WarehouseID = 1
                        },
                        new
                        {
                            StockID = 2,
                            Quantity = 20,
                            VariantID = 1,
                            WarehouseID = 2
                        },
                        new
                        {
                            StockID = 3,
                            Quantity = 30,
                            VariantID = 3,
                            WarehouseID = 3
                        },
                        new
                        {
                            StockID = 4,
                            Quantity = 40,
                            VariantID = 4,
                            WarehouseID = 4
                        },
                        new
                        {
                            StockID = 5,
                            Quantity = 50,
                            VariantID = 5,
                            WarehouseID = 5
                        });
                });

            modelBuilder.Entity("dotAshFashionNexus.Persistence.Models.Variant", b =>
                {
                    b.Property<int>("VariantID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("VariantID"));

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("ProductID")
                        .HasColumnType("integer");

                    b.Property<string>("Size")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("VariantID");

                    b.HasIndex("ProductID");

                    b.ToTable("Variants");

                    b.HasData(
                        new
                        {
                            VariantID = 1,
                            Color = "Red",
                            ProductID = 1,
                            Size = "Small"
                        },
                        new
                        {
                            VariantID = 2,
                            Color = "Blue",
                            ProductID = 1,
                            Size = "Medium"
                        },
                        new
                        {
                            VariantID = 3,
                            Color = "Green",
                            ProductID = 2,
                            Size = "Large"
                        },
                        new
                        {
                            VariantID = 4,
                            Color = "Black",
                            ProductID = 3,
                            Size = "Small"
                        },
                        new
                        {
                            VariantID = 5,
                            Color = "White",
                            ProductID = 4,
                            Size = "Medium"
                        });
                });

            modelBuilder.Entity("dotAshFashionNexus.Persistence.Models.Warehouse", b =>
                {
                    b.Property<int>("WarehouseID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("WarehouseID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("WarehouseID");

                    b.ToTable("Warehouses");

                    b.HasData(
                        new
                        {
                            WarehouseID = 1,
                            Name = "Warehouse 1"
                        },
                        new
                        {
                            WarehouseID = 2,
                            Name = "Warehouse 2"
                        },
                        new
                        {
                            WarehouseID = 3,
                            Name = "Warehouse 3"
                        },
                        new
                        {
                            WarehouseID = 4,
                            Name = "Warehouse 4"
                        },
                        new
                        {
                            WarehouseID = 5,
                            Name = "Warehouse 5"
                        });
                });

            modelBuilder.Entity("dotAshFashionNexus.Persistence.Models.Stock", b =>
                {
                    b.HasOne("dotAshFashionNexus.Persistence.Models.Variant", "Variant")
                        .WithMany("Stocks")
                        .HasForeignKey("VariantID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("dotAshFashionNexus.Persistence.Models.Warehouse", "Warehouse")
                        .WithMany("Stocks")
                        .HasForeignKey("WarehouseID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Variant");

                    b.Navigation("Warehouse");
                });

            modelBuilder.Entity("dotAshFashionNexus.Persistence.Models.Variant", b =>
                {
                    b.HasOne("dotAshFashionNexus.Persistence.Models.Product", "Product")
                        .WithMany("Variants")
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("dotAshFashionNexus.Persistence.Models.Product", b =>
                {
                    b.Navigation("Variants");
                });

            modelBuilder.Entity("dotAshFashionNexus.Persistence.Models.Variant", b =>
                {
                    b.Navigation("Stocks");
                });

            modelBuilder.Entity("dotAshFashionNexus.Persistence.Models.Warehouse", b =>
                {
                    b.Navigation("Stocks");
                });
#pragma warning restore 612, 618
        }
    }
}
