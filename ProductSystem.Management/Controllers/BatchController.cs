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
    public class BatchController : ControllerBase
    {
        private readonly IRepository<Batch> _repo;
        private readonly IRepository<WarehouseProduct> _prodWarRepo;
        private readonly IRepository<Product> _prodRepo;

        public BatchController(IRepository<Batch> repo, IRepository<WarehouseProduct> prodWarRepo, IRepository<Product> prodRepo)
        {
            _repo = repo;
            _prodWarRepo = prodWarRepo;
            _prodRepo = prodRepo;
        }

        [HttpGet("id")]
        public ActionResult GetBatch([FromRoute] Guid id)
        {
            return Ok(_repo.DataSet.Include(x => x.Product).Include(x => x.Warehouse).FirstOrDefault(x => x.Id == id));
        }

        [HttpPost("add")]
        public ActionResult CreateBatch([FromBody] BatchDto dto)
        {
            List<Product> products = _prodRepo.GetByExpression(x => true).Data;
            Batch batchDb = new Batch()
            {
                Width = dto.Width,
                Height = dto.Height,
                Length = dto.Length,
                Amount = dto.Amount,
                ProductId = dto.ProductId,
                WarehouseId = dto.WarehouseId,
            };
            var result = _repo.Save(batchDb);
            return Ok(_repo.DataSet.Include(w => w.Warehouse).Include(p => p.Product).FirstOrDefault(x => x.Id == Guid.Parse(result.Message)));
        }
    }
}