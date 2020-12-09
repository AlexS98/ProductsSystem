using Microsoft.AspNetCore.Mvc;

namespace ProductsSystem.Auth.Controllers
{
    public class Ping : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}