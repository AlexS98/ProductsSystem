using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ProductSystem.Management.Database.Repository;
using ProductSystem.Management.Dto;
using ProductSystem.Management.Models;
using ProductSystem.Management.Services;

namespace ProductSystem.Management.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TransferController : ControllerBase
    {
        private readonly IRepository<Transfer> _repo;
        private readonly IRepository<Product> _prodRepo;
        private readonly IMessageService _message;

        public TransferController(IRepository<Transfer> repo, IRepository<Product> prodRepo, IMessageService message)
        {
            _repo = repo;
            _prodRepo = prodRepo;
            _message = message;
        }

        [HttpGet("id")]
        public ActionResult GetTransfer([FromRoute] Guid id)
        {
            return Ok(_repo.DataSet.Include(x => x.ToWarehouse).Include(x => x.ToSellPoint).FirstOrDefault(x => x.Id == id));
        }

        [HttpPost("add")]
        public ActionResult CreateTransfer([FromBody] TransferDto dto)
        {
            Transfer batchDb = new Transfer()
            {
                ToSellPointId = dto.ToSellPointId,
                ToWarehouseId = dto.ToWarehouseId,
                BatchId = dto.BatchId
            };
            var result = _repo.Save(batchDb);

            var newTransfer = _repo.DataSet.Include(w => w.ToWarehouse).Include(p => p.ToSellPoint).FirstOrDefault(x => x.Id == Guid.Parse(result.Message));
            _message.Enqueue(JsonConvert.SerializeObject(newTransfer));

            return Ok(newTransfer);
        }
    }
}