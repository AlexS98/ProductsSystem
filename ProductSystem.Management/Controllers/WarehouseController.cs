using Microsoft.AspNetCore.Mvc;
using ProductSystem.Management.Database.Repository;
using ProductSystem.Management.Dto;
using ProductSystem.Management.Models;

namespace ProductSystem.Management.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WarehouseController : ControllerBase
    {
        private readonly IRepository<Warehouse> _repo;

        public WarehouseController(IRepository<Warehouse> repo)
        {
            _repo = repo;
        }

        [HttpPost("add")]
        public object CreateWarehouse([FromBody] WarehouseDto dto)
        {
            return null;
        }
    }
}