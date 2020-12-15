using System;
namespace ProductSystem.Management.Models
{
    public class Transfer : CommonModel
    {
        public Guid BatchId { get; set; }
        public Batch Batch { get; set; }
        public Guid? ToWarehouseId { get; set; }
        public Warehouse ToWarehouse { get; set; }
        public Guid? ToSellPointId { get; set; }
        public SellPoint ToSellPoint { get; set; }
    }
}