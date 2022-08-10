using Microsoft.AspNetCore.Mvc;

namespace FridgeProductsApp.MVC.Controllers
{
    public class ModelController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
