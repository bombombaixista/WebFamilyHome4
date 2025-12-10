using Microsoft.AspNetCore.Mvc;

namespace WebFamilyHome.Controllers
{
    public class ValidateController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            // 👉 Renderiza a View (Views/Validate/Index.cshtml)
            return View();
        }

        [HttpPost]
        public IActionResult Index(string token)
        {
            if (token == "minha_chave_secreta")
            {
                // ✅ Token válido → redireciona para o Kanban
                return Redirect("https://kanban-seuapp.com/Home/Index");
            }
            else
            {
                // ❌ Token inválido → mostra erro na própria tela
                ViewBag.Erro = "Token inválido!";
                return View();
            }
        }
    }
}
