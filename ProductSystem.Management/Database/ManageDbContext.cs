using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using ProductSystem.Management.Models;

namespace ProductSystem.Management.Database
{
    public class ManageDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Batch> Batches { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<WarehouseProduct> WarehouseProducts { get; set; }
        public DbSet<SellPoint> SellPoints { get; set; }
        public DbSet<Transfer> Transfers { get; set; }


        public ManageDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var products = new[] {
                new Product
                {
                    Id = Guid.Parse("9C126DF2-63C4-4005-8190-F2B9B5E762B0"),
                    Name = "Stone",
                    Code = "stn"
                },
                new Product
                {
                    Id = Guid.Parse("3AE4C2C5-C821-4BAA-A3AD-673AEF94A946"),
                    Name = "Wood",
                    Code = "wd"
                },
                new Product
                {
                    Id = Guid.Parse("DD01763E-6EBB-49B9-BD23-3FB5DD34A9AE"),
                    Name = "Steel",
                    Code = "stl"
                },
                new Product
                {
                    Id = Guid.Parse("FA031419-66B3-41F9-9EAA-8CCEDA79E890"),
                    Name = "Gold",
                    Code = "gd"
                },
                new Product
                {
                    Id = Guid.Parse("A609390C-B3FE-4989-B78C-E8A38562B7EC"),
                    Name = "Coal",
                    Code = "cl"
                }
            };

            modelBuilder
                .Entity<Product>()
                .HasData(products);

            var warehouses = new[] {
                new Warehouse
                {
                    Id = Guid.Parse("1E498CDC-803B-4B74-9E9A-00EC6C2E3F24"),
                    Name = "Warhouse 1",
                    Address = "Kyiv, Ukraine",
                    Capacity = 250,
                    FunctioningCapacity = 0
                },
                new Warehouse
                {
                    Id = Guid.Parse("8C8D3D9E-B532-4DAA-B95D-9BF8FDB56092"),
                    Name = "Warhouse 2",
                    Address = "Lviv, Ukraine",
                    Capacity = 180,
                    FunctioningCapacity = 0
                },
                new Warehouse
                {
                    Id = Guid.Parse("6CC495EA-E737-4F69-B630-277C56F126FA"),
                    Name = "Warhouse 3",
                    Address = "Kharkiv, Ukraine",
                    Capacity = 210,
                    FunctioningCapacity = 0
                }
            };

            modelBuilder
                .Entity<Warehouse>()
                .HasData(warehouses);

            var warehouseProd = new[] {
                new WarehouseProduct {
                    Id = Guid.NewGuid(),
                    ProductId = products[0].Id,
                    WarehouseId = warehouses[0].Id
                },
                new WarehouseProduct {
                    Id = Guid.NewGuid(),
                    ProductId= products[1].Id,
                    WarehouseId = warehouses[0].Id
                },
                new WarehouseProduct {
                    Id = Guid.NewGuid(),
                    ProductId = products[2].Id,
                    WarehouseId = warehouses[0].Id
                },
                new WarehouseProduct {
                    Id = Guid.NewGuid(),
                    ProductId = products[3].Id,
                    WarehouseId = warehouses[0].Id
                },
                new WarehouseProduct {
                    Id = Guid.NewGuid(),
                    ProductId = products[1].Id,
                    WarehouseId = warehouses[1].Id
                },
                new WarehouseProduct {
                    Id = Guid.NewGuid(),
                    ProductId = products[2].Id,
                    WarehouseId = warehouses[1].Id
                },
                new WarehouseProduct {
                    Id = Guid.NewGuid(),
                    ProductId = products[4].Id,
                    WarehouseId= warehouses[1].Id
                },
                new WarehouseProduct {
                    Id = Guid.NewGuid(),
                    ProductId = products[3].Id,
                    WarehouseId = warehouses[2].Id
                },
                new WarehouseProduct {
                    Id = Guid.NewGuid(),
                    ProductId = products[0].Id,
                    WarehouseId = warehouses[2].Id
                }
            };

            modelBuilder
                .Entity<WarehouseProduct>()
                .HasData(warehouseProd);


            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(cancellationToken);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        public override EntityEntry<TEntity> Entry<TEntity>(TEntity entity)
        {
            return base.Entry(entity);
        }

        public override EntityEntry Entry(object entity)
        {
            return base.Entry(entity);
        }

        public override EntityEntry<TEntity> Add<TEntity>(TEntity entity)
        {
            return base.Add(entity);
        }

        public override ValueTask<EntityEntry<TEntity>> AddAsync<TEntity>(TEntity entity, CancellationToken cancellationToken = default)
        {
            return base.AddAsync(entity, cancellationToken);
        }

        public override EntityEntry<TEntity> Attach<TEntity>(TEntity entity)
        {
            return base.Attach(entity);
        }

        public override EntityEntry<TEntity> Update<TEntity>(TEntity entity)
        {
            return base.Update(entity);
        }

        public override EntityEntry<TEntity> Remove<TEntity>(TEntity entity)
        {
            return base.Remove(entity);
        }

        public override EntityEntry Add(object entity)
        {
            return base.Add(entity);
        }

        public override ValueTask<EntityEntry> AddAsync(object entity, CancellationToken cancellationToken = default)
        {
            return base.AddAsync(entity, cancellationToken);
        }

        public override EntityEntry Attach(object entity)
        {
            return base.Attach(entity);
        }

        public override EntityEntry Update(object entity)
        {
            return base.Update(entity);
        }

        public override EntityEntry Remove(object entity)
        {
            return base.Remove(entity);
        }

        public override void AddRange(params object[] entities)
        {
            base.AddRange(entities);
        }

        public override Task AddRangeAsync(params object[] entities)
        {
            return base.AddRangeAsync(entities);
        }

        public override void AttachRange(params object[] entities)
        {
            base.AttachRange(entities);
        }

        public override void UpdateRange(params object[] entities)
        {
            base.UpdateRange(entities);
        }

        public override void RemoveRange(params object[] entities)
        {
            base.RemoveRange(entities);
        }

        public override void AddRange(IEnumerable<object> entities)
        {
            base.AddRange(entities);
        }

        public override Task AddRangeAsync(IEnumerable<object> entities, CancellationToken cancellationToken = default)
        {
            return base.AddRangeAsync(entities, cancellationToken);
        }

        public override void AttachRange(IEnumerable<object> entities)
        {
            base.AttachRange(entities);
        }

        public override void UpdateRange(IEnumerable<object> entities)
        {
            base.UpdateRange(entities);
        }

        public override void RemoveRange(IEnumerable<object> entities)
        {
            base.RemoveRange(entities);
        }

        public override object Find(Type entityType, params object[] keyValues)
        {
            return base.Find(entityType, keyValues);
        }

        public override ValueTask<object> FindAsync(Type entityType, params object[] keyValues)
        {
            return base.FindAsync(entityType, keyValues);
        }

        public override ValueTask<object> FindAsync(Type entityType, object[] keyValues, CancellationToken cancellationToken)
        {
            return base.FindAsync(entityType, keyValues, cancellationToken);
        }

        public override TEntity Find<TEntity>(params object[] keyValues)
        {
            return base.Find<TEntity>(keyValues);
        }

        public override ValueTask<TEntity> FindAsync<TEntity>(params object[] keyValues)
        {
            return base.FindAsync<TEntity>(keyValues);
        }

        public override ValueTask<TEntity> FindAsync<TEntity>(object[] keyValues, CancellationToken cancellationToken)
        {
            return base.FindAsync<TEntity>(keyValues, cancellationToken);
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}