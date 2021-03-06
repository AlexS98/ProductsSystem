using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProductSystem.Gateway.Services.Interfaces;

namespace ProductSystem.Gateway.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PingController : ControllerBase
    {
        private readonly IRequestService _pingService;

        public PingController(IRequestService pingService)
        {
            _pingService = pingService;
        }

        [HttpGet]
        public async Task<List<string>> Ping()
        {
            var response = new List<string>() { "Gateway is ok!" };
            
            response.Add(await _pingService.PingDockerServiceAsync("authservice", 5001));
            response.Add(await _pingService.PingDockerServiceAsync("managservice", 5003));

            return response;
        }
    }
}