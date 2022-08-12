using FridgeProductsApp.Domain.DTO.User;
using Microsoft.AspNetCore.Mvc;

namespace FridgeProductsApp.MVC.Controllers
{
    public class AuthenticationController : Controller
    {
        private string _host = "https://localhost:5001/api/Authentication/";

        public AuthenticationController()
        { }

        [HttpGet]
        public IActionResult Authenticate()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Authenticate(UserForAuthenticationDto authenticationUser)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            using HttpClient httpClient = new();
            var result = await httpClient.PostAsJsonAsync(_host + "Authenticate/", authenticationUser);

            if (result.IsSuccessStatusCode)
            {
                var token = result.Content.ReadAsStringAsync().Result;
                Response.Cookies.Append("X-Access-Token", token, new CookieOptions
                {
                    MaxAge = TimeSpan.FromMinutes(1)
                });

                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }

            ViewData["Message"] = "Login or password is not correct!";
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            var roles = new string[] { "Administrator", "Manager" };

            return View(new UserForRegistrationDto()
            {
                Roles = roles.ToList()
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(UserForRegistrationDto userForRegistration)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            using HttpClient httpClient = new();
            var result = await httpClient.PostAsJsonAsync(_host + "RegisterUser/", userForRegistration);

            if (result.IsSuccessStatusCode)
            {
                return RedirectToRoute(new { controller = "Authentication", action = "Authenticate" });
            }

            ViewData["Message"] = "Something went wrong!";
            return View();
        }
    }
}
