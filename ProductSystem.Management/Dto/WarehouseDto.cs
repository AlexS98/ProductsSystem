using System;
using System.Collections.Generic;
namespace ProductSystem.Management.Dto
{
    public class WarehouseDto
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public float Capacity { get; set; }
        public float FunctioningCapacity { get; set; }
        public List<Guid> ProductsIds { get; set; } = new List<Guid>();
    }
}