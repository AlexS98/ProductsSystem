using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ProductSystem.Gateway.RequestModels;
using ProductSystem.Gateway.Services.Concrete;
using ProductSystem.Gateway.Services.Interfaces;

namespace ProductSystem.Management.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BatchController : ControllerBase
    {
        private readonly IRequestService _requestService;

        public BatchController(IRequestService requestService)
        {
            _requestService = requestService;
        }

        [HttpGet("id")]
        public async System.Threading.Tasks.Task<ActionResult> GetBatchAsync([FromRoute] Guid id)
        {
            return Ok(await _requestService.GetFromDockerServiceAsync(
                RequestService.managservice, RequestService.managservicePort, "/batch/id", new Dictionary<string, string>() { { "id", id.ToString() } }));
        }

        [HttpPost("add")]
        public async System.Threading.Tasks.Task<ActionResult> CreateBatchAsync([FromBody] BatchDto dto)
        {
            return Ok(await _requestService.PostFromDockerServiceAsync(RequestService.managservice, RequestService.managservicePort, "/batch/add", dto));
        }
    }
}