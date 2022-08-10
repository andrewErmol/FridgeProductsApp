using Microsoft.AspNetCore.Mvc;

namespace FridgeProductsApp.MVC.Controllers
{
    public class FridgeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
