﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProductSystem.Management.Database;

namespace ProductSystem.Management.Migrations
{
    [DbContext(typeof(ManageDbContext))]
    [Migration("20201213234959_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ProductSystem.Management.Models.Batch", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset?>("CreateDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<float>("Height")
                        .HasColumnType("real");

                    b.Property<float>("Length")
                        .HasColumnType("real");

                    b.Property<Guid?>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset?>("UpdateDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid?>("WarehouseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<float>("Width")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("WarehouseId");

                    b.ToTable("Batches");
                });

            modelBuilder.Entity("ProductSystem.Management.Models.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset?>("CreateDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Origin")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset?>("UpdateDate")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("ProductSystem.Management.Models.SellPoint", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset?>("CreateDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("DeliveryNotes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset?>("UpdateDate")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("Id");

                    b.ToTable("SellPoints");
                });

            modelBuilder.Entity("ProductSystem.Management.Models.Transfer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("BatchId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset?>("CreateDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid?>("ToSellPointId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ToWarehouseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset?>("UpdateDate")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("Id");

                    b.HasIndex("BatchId");

                    b.HasIndex("ToSellPointId");

                    b.HasIndex("ToWarehouseId");

                    b.ToTable("Transfers");
                });

            modelBuilder.Entity("ProductSystem.Management.Models.Warehouse", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Capacity")
                        .HasColumnType("real");

                    b.Property<DateTimeOffset?>("CreateDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<float>("FunctioningCapacity")
                        .HasColumnType("real");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset?>("UpdateDate")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("Id");

                    b.ToTable("Warehouses");
                });

            modelBuilder.Entity("ProductSystem.Management.Models.WarehouseProduct", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset?>("CreateDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid?>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset?>("UpdateDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid?>("WarehouseId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("WarehouseId");

                    b.ToTable("WarehouseProducts");
                });

            modelBuilder.Entity("ProductSystem.Management.Models.Batch", b =>
                {
                    b.HasOne("ProductSystem.Management.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId");

                    b.HasOne("ProductSystem.Management.Models.Warehouse", "Warehouse")
                        .WithMany("Batches")
                        .HasForeignKey("WarehouseId");
                });

            modelBuilder.Entity("ProductSystem.Management.Models.Transfer", b =>
                {
                    b.HasOne("ProductSystem.Management.Models.Batch", "Batch")
                        .WithMany()
                        .HasForeignKey("BatchId");

                    b.HasOne("ProductSystem.Management.Models.SellPoint", "ToSellPoint")
                        .WithMany()
                        .HasForeignKey("ToSellPointId");

                    b.HasOne("ProductSystem.Management.Models.Warehouse", "ToWarehouse")
                        .WithMany()
                        .HasForeignKey("ToWarehouseId");
                });

            modelBuilder.Entity("ProductSystem.Management.Models.WarehouseProduct", b =>
                {
                    b.HasOne("ProductSystem.Management.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId");

                    b.HasOne("ProductSystem.Management.Models.Warehouse", "Warehouse")
                        .WithMany("AvailableProducts")
                        .HasForeignKey("WarehouseId");
                });
#pragma warning restore 612, 618
        }
    }
}
