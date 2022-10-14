using Microsoft.AspNetCore.Mvc;

namespace Playground.MVC.Controllers
{
    public class LocationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
