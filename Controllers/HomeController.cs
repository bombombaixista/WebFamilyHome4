using Microsoft.AspNetCore.Mvc;

namespace WebFamilyHome.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Title"] = "Página Inicial";
            return View();
        }

        public IActionResult Privacy()
        {
            ViewData["Title"] = "Privacidade";
            return View();
        }

        public IActionResult Login()
        {
            ViewData["Title"] = "Login";
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
