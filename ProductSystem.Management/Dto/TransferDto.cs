using System;

namespace ProductSystem.Management.Dto
{
    public class TransferDto
    {
        public Guid BatchId { get; set; }
        public Guid? ToWarehouseId { get; set; }
        public Guid? ToSellPointId { get; set; }
    }
}