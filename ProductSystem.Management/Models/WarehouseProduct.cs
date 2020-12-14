namespace ProductSystem.Management.Models
{
    public class WarehouseProduct : CommonModel
    {
        public Warehouse Warehouse { get; set; }
        public Product Product { get; set; }
    }
}