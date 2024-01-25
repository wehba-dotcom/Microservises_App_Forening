using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IdentityService.Controllers
{
    public class RoleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Manager()
        {
            return View();
        }

       
        public IActionResult Admin()
        {
            return View();
        }
    }
}
