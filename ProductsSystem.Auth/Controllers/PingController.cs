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
        private readonly AuthDbContext _context;

        public PingController(AuthDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Ping()
        {
            return Ok("Ping successful!");
        }

        [HttpGet("users")]
        public async Task<IActionResult> PingUsersAsync()
        {
            var users = await _context.Users.ToListAsync();
            return Ok(users);
        }
    }
}