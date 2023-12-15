using Bornholm_Sleagts.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bornholm_Sleagts.Controllers
{
    public class RoleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Policy = "RequireAdmin")]
        public IActionResult Manager()
        {
            return View();
        }

        [Authorize(Policy = "RequireAdmin")]
        [Authorize(Policy = $"{"RequireAdmin"}")]
        public IActionResult Admin()
        {
            return View();
        }
    }
}
