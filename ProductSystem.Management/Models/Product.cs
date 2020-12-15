using System.Collections.Generic;

namespace ProductSystem.Management.Models
{
    public class Product : CommonModel
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string Origin { get; set; }
        public List<Warehouse> AvailableProducts { get; set; }
    }
}