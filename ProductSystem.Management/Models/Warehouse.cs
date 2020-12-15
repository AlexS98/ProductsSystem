using System.Collections.Generic;

namespace ProductSystem.Management.Models
{
    public class Warehouse : CommonModel
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public float Capacity { get; set; }
        public float FunctioningCapacity { get; set; }
        public List<Batch> Batches { get; set; }
        public List<Product> AvailableProducts { get; set; }
    }
}