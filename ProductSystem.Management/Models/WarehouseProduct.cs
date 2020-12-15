using System;

namespace ProductSystem.Management.Models
{
    public class WarehouseProduct : CommonModel
    {
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        public Guid WarehouseId { get; set; }
        public Warehouse Warehouse { get; set; }
    }
}