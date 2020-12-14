using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ProductsSystem.Auth.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PingController : ControllerBase
    {
        [HttpGet]
        public IActionResult Ping()
        {
            return Ok("Ping successful!");
        }
    }
}