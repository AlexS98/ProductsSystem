using System;

namespace ProductSystem.Management.Models
{
    public class Batch : CommonModel
    {
        public float Width { get; set; }
        public float Length { get; set; }
        public float Height { get; set; }
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        public int Amount { get; set; }
        public Guid WarehouseId { get; set; }
        public Warehouse Warehouse { get; set; }
    }
}