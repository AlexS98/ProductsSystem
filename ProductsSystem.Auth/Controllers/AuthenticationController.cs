using Microsoft.AspNetCore.Mvc;
using ProductsSystem.Auth.RequestModels;

namespace ProductsSystem.Auth.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthenticationController : ControllerBase
    {
        
        
        [HttpPost("sign-in")]
        public ActionResult SignIn([FromBody] SignInUser user)
        {
            return BadRequest();
        }
    }
}