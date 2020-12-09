using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductsSystem.Auth.Database;

namespace ProductsSystem.Auth.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PingController : ControllerBase
    {
        [HttpGet]
        public IActionResult Ping()
        {
            // var users = await _context.Users.ToListAsync();
            return Ok("Ping successful!");
        }
    }
}