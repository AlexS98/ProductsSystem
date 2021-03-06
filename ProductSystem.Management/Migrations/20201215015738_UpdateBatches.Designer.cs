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
    [Migration("20201215015738_UpdateBatches")]
    partial class UpdateBatches
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

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset?>("UpdateDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid>("WarehouseId")
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

                    b.HasData(
                        new
                        {
                            Id = new Guid("9c126df2-63c4-4005-8190-f2b9b5e762b0"),
                            Code = "stn",
                            Name = "Stone"
                        },
                        new
                        {
                            Id = new Guid("3ae4c2c5-c821-4baa-a3ad-673aef94a946"),
                            Code = "wd",
                            Name = "Wood"
                        },
                        new
                        {
                            Id = new Guid("dd01763e-6ebb-49b9-bd23-3fb5dd34a9ae"),
                            Code = "stl",
                            Name = "Steel"
                        },
                        new
                        {
                            Id = new Guid("fa031419-66b3-41f9-9eaa-8cceda79e890"),
                            Code = "gd",
                            Name = "Gold"
                        },
                        new
                        {
                            Id = new Guid("a609390c-b3fe-4989-b78c-e8a38562b7ec"),
                            Code = "cl",
                            Name = "Coal"
                        });
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

                    b.Property<Guid>("BatchId")
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

                    b.HasData(
                        new
                        {
                            Id = new Guid("1e498cdc-803b-4b74-9e9a-00ec6c2e3f24"),
                            Address = "Kyiv, Ukraine",
                            Capacity = 250f,
                            FunctioningCapacity = 0f,
                            Name = "Warhouse 1"
                        },
                        new
                        {
                            Id = new Guid("8c8d3d9e-b532-4daa-b95d-9bf8fdb56092"),
                            Address = "Lviv, Ukraine",
                            Capacity = 180f,
                            FunctioningCapacity = 0f,
                            Name = "Warhouse 2"
                        },
                        new
                        {
                            Id = new Guid("6cc495ea-e737-4f69-b630-277c56f126fa"),
                            Address = "Kharkiv, Ukraine",
                            Capacity = 210f,
                            FunctioningCapacity = 0f,
                            Name = "Warhouse 3"
                        });
                });

            modelBuilder.Entity("ProductSystem.Management.Models.WarehouseProduct", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset?>("CreateDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset?>("UpdateDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid>("WarehouseId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("WarehouseId");

                    b.ToTable("WarehouseProducts");

                    b.HasData(
                        new
                        {
                            Id = new Guid("502f6c77-a0ce-4d3d-a995-d1b042208f93"),
                            ProductId = new Guid("9c126df2-63c4-4005-8190-f2b9b5e762b0"),
                            WarehouseId = new Guid("1e498cdc-803b-4b74-9e9a-00ec6c2e3f24")
                        },
                        new
                        {
                            Id = new Guid("ee113b4e-fd95-41f6-8e2c-ff7de0df8069"),
                            ProductId = new Guid("3ae4c2c5-c821-4baa-a3ad-673aef94a946"),
                            WarehouseId = new Guid("1e498cdc-803b-4b74-9e9a-00ec6c2e3f24")
                        },
                        new
                        {
                            Id = new Guid("3231b6ec-53cb-4c30-8756-7636fde22859"),
                            ProductId = new Guid("dd01763e-6ebb-49b9-bd23-3fb5dd34a9ae"),
                            WarehouseId = new Guid("1e498cdc-803b-4b74-9e9a-00ec6c2e3f24")
                        },
                        new
                        {
                            Id = new Guid("99967649-0729-46a2-ad90-d733869b9762"),
                            ProductId = new Guid("fa031419-66b3-41f9-9eaa-8cceda79e890"),
                            WarehouseId = new Guid("1e498cdc-803b-4b74-9e9a-00ec6c2e3f24")
                        },
                        new
                        {
                            Id = new Guid("5536c82d-caa7-44e3-a2d9-423d676bbdb8"),
                            ProductId = new Guid("3ae4c2c5-c821-4baa-a3ad-673aef94a946"),
                            WarehouseId = new Guid("8c8d3d9e-b532-4daa-b95d-9bf8fdb56092")
                        },
                        new
                        {
                            Id = new Guid("c0c63120-4357-461d-8139-df92fa81cc8b"),
                            ProductId = new Guid("dd01763e-6ebb-49b9-bd23-3fb5dd34a9ae"),
                            WarehouseId = new Guid("8c8d3d9e-b532-4daa-b95d-9bf8fdb56092")
                        },
                        new
                        {
                            Id = new Guid("b512951a-6533-4a7e-8abd-0a15189af3b1"),
                            ProductId = new Guid("a609390c-b3fe-4989-b78c-e8a38562b7ec"),
                            WarehouseId = new Guid("8c8d3d9e-b532-4daa-b95d-9bf8fdb56092")
                        },
                        new
                        {
                            Id = new Guid("e0b8aaac-bdb6-46d1-a9bf-9ecfa82a4022"),
                            ProductId = new Guid("fa031419-66b3-41f9-9eaa-8cceda79e890"),
                            WarehouseId = new Guid("6cc495ea-e737-4f69-b630-277c56f126fa")
                        },
                        new
                        {
                            Id = new Guid("b97b08a7-0d08-41a3-a19d-d8c5764b75e3"),
                            ProductId = new Guid("9c126df2-63c4-4005-8190-f2b9b5e762b0"),
                            WarehouseId = new Guid("6cc495ea-e737-4f69-b630-277c56f126fa")
                        });
                });

            modelBuilder.Entity("ProductSystem.Management.Models.Batch", b =>
                {
                    b.HasOne("ProductSystem.Management.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProductSystem.Management.Models.Warehouse", "Warehouse")
                        .WithMany("Batches")
                        .HasForeignKey("WarehouseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProductSystem.Management.Models.Transfer", b =>
                {
                    b.HasOne("ProductSystem.Management.Models.Batch", "Batch")
                        .WithMany()
                        .HasForeignKey("BatchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

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
                        .WithMany("AvailableProducts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProductSystem.Management.Models.Warehouse", "Warehouse")
                        .WithMany("AvailableProducts")
                        .HasForeignKey("WarehouseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
