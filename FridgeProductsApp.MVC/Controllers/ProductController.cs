using Microsoft.AspNetCore.Mvc;

namespace FridgeProductsApp.MVC.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
