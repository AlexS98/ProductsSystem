using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProductSystem.Gateway.RequestModels;
using ProductSystem.Gateway.Services.Concrete;
using ProductSystem.Gateway.Services.Interfaces;

namespace ProductSystem.Management.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TransferController : ControllerBase
    {
         private readonly IRequestService _requestService;

        public TransferController(IRequestService requestService)
        {
            _requestService = requestService;
        }

        [HttpGet("id")]
        public async Task<ActionResult> GetTransferAsync([FromRoute] Guid id)
        {
            return Ok(await _requestService.GetFromDockerServiceAsync(
                RequestService.managservice, RequestService.managservicePort, "/transfer/id", new Dictionary<string, string>() { { "id", id.ToString() } }));
        }

        [HttpPost("add")]
        public async Task<ActionResult> CreateTransferAsync([FromBody] TransferDto dto)
        {
            return Ok(await _requestService.PostFromDockerServiceAsync(RequestService.managservice, RequestService.managservicePort, "/transfer/add", dto));
        }
    }
}