using Microsoft.AspNetCore.Mvc;

namespace FridgeProductsApp.MVC.Controllers
{
    public class FridgeProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
