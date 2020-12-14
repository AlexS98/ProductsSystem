using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductSystem.Gateway.RequestModels;
using ProductSystem.Gateway.Services.Concrete;
using ProductSystem.Gateway.Services.Interfaces;

namespace ProductSystem.Gateway.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IRequestService _requestService;

        public AuthenticationController(IRequestService requestService)
        {
            _requestService = requestService;
        }

        [HttpPost("sign-in")]
        public async Task<ActionResult> SignInAsync([FromBody] SignInUser signInUser)
        {
            return Ok(await _requestService.PostFromDockerServiceAsync(RequestService.authservice, RequestService.authservicePort, "/auth/sign-in", signInUser));
        }

        [HttpPost("sign-up")]
        public async Task<ActionResult> SignUpAsync([FromBody] RegisterUser signInUser)
        {
            return Ok(await _requestService.PostFromDockerServiceAsync(RequestService.authservice, RequestService.authservicePort, "/auth/sign-up", signInUser));
        }

        [HttpGet("check")]
        public async Task<ActionResult> CheckAsync()
        {
            var bearer = HttpContext.Request.Headers.TryGetValue("Authorization", out var values) ? values.FirstOrDefault()?.Split(" ")[1] : null;
            return Ok(await _requestService.GetFromDockerServiceAsync(RequestService.authservice, RequestService.authservicePort, "/auth/check", bearer));
        }

    }
}