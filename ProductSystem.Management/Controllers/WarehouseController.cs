using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        private readonly IRepository<WarehouseProduct> _prodWarRepo;
        private readonly IRepository<Product> _prodRepo;

        public WarehouseController(IRepository<Warehouse> repo, IRepository<WarehouseProduct> prodWarRepo, IRepository<Product> prodRepo)
        {
            _repo = repo;
            _prodWarRepo = prodWarRepo;
            _prodRepo = prodRepo;
        }

        [HttpGet("id")]
        public ActionResult GetWarehouse([FromRoute] Guid id)
        {
            return Ok(_repo.DataSet.Include(w => w.AvailableProducts).ThenInclude(w => w.Product).FirstOrDefault(x => x.Id == id));
        }

        [HttpPost("add")]
        public ActionResult CreateWarehouse([FromBody] WarehouseDto dto)
        {
            List<Product> products = _prodRepo.GetByExpression(x => true).Data;
            Warehouse warehouseDb = new Warehouse()
            {
                Name = dto.Name,
                Address = dto.Address,
                Capacity = dto.Capacity,
                FunctioningCapacity = dto.FunctioningCapacity,
                AvailableProducts = new List<WarehouseProduct>()
            };
            var result = _repo.Save(warehouseDb);
            var existedproducts = dto.ProductsIds
                .Select(x => products.FirstOrDefault(y => y.Id == x))
                .Where(x => x != null);
            foreach (var prod in existedproducts)
            {
                WarehouseProduct newProd = new WarehouseProduct()
                {
                    Warehouse = warehouseDb,
                    Product = prod
                };
                _prodWarRepo.Save(newProd);
            }
            return Ok(_repo.DataSet.Include(w => w.AvailableProducts).Where(x => x.Id == Guid.Parse(result.Message)));
        }
    }
}