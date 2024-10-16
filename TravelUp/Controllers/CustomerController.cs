using Microsoft.AspNetCore.Mvc;

namespace TravelUp.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult List()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}
