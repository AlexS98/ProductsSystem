using System;

namespace ProductSystem.Management.Dto
{
    public class BatchDto
    {
        public float Width { get; set; }
        public float Length { get; set; }
        public float Height { get; set; }
        public Guid ProductId { get; set; }
        public int Amount { get; set; }
        public Guid WarehouseId { get; set; }
    }
}