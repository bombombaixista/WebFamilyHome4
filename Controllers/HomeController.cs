using Microsoft.AspNetCore.Mvc;

namespace WebFamilyHome.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Title"] = "WebFamily";
            return View();
        }

        public IActionResult Privacy()
        {
            ViewData["Title"] = "Privacidade";
            return View();
        }

        public IActionResult Login()
        {
            ViewData["Title"] = "login";
            return View();
        }

        public IActionResult Cadastro()
        {
            ViewData["Title"] = "Cadastro";
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
