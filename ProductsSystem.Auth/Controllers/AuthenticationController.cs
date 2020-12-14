using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductsSystem.Auth.Database;
using ProductsSystem.Auth.Database.Repository;
using ProductsSystem.Auth.Models;
using ProductsSystem.Auth.RequestModels;
using ProductsSystem.Auth.Services.Abstract;
using ProductsSystem.Auth.Services.Helpers;

namespace ProductsSystem.Auth.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IJwtService _jwtService;
        private readonly IRepository<User> _userRepo;

        public AuthenticationController(IJwtService jwtService, IRepository<User> userRepo)
        {
            _jwtService = jwtService;
            _userRepo = userRepo;
        }

        [HttpPost("sign-in")]
        public ActionResult SignInAsync([FromBody] SignInUser signInUser)
        {
            var userDb = _userRepo.GetOneByExpression(x => x.Username == signInUser.Username);

            if (!userDb.Success || userDb.Data == null)
            {
                return BadRequest("Wrong username");
            }

            if (!Hash.Validate(signInUser.Password, userDb.Data.PasswordHash))
            {
                return BadRequest("Wrong password");
            }

            var identity = _jwtService.GetIdentityFromUser(userDb.Data);
            var token = _jwtService.GenerateToken(identity.Claims);

            return Ok(new { Token = token, User = userDb.Data });
        }

        [HttpPost("sign-up")]
        public ActionResult SignUpAsync([FromBody] RegisterUser signInUser)
        {
            var userDb = _userRepo.GetOneByExpression(x => x.Username == signInUser.Username);

            if (!userDb.Success || userDb.Data != null)
            {
                return BadRequest("Username already in use.");
            }

            var newUser = new User
            {
                Username = signInUser.Username,
                PasswordHash = Hash.Create(signInUser.Password),
                Email = signInUser.Email
            };

            _userRepo.Save(newUser);
            userDb = _userRepo.GetOneByExpression(x => x.Username == signInUser.Username);

            var identity = _jwtService.GetIdentityFromUser(userDb.Data);
            var token = _jwtService.GenerateToken(identity.Claims);

            return Ok(new { Token = token, User = userDb.Data });
        }

        [HttpGet("check")]
        [Authorize]
        public ActionResult Check(){
            return Ok();
        }

    }
}