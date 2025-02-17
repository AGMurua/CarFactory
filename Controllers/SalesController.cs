using Microsoft.AspNetCore.Mvc;

namespace CarFactory.Controllers
{
    public class SalesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
