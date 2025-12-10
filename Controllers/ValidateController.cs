using Microsoft.AspNetCore.Mvc;

namespace WebFamilyHome.Controllers
{
    public class ValidateController : Controller
    {
        public IActionResult Index()
        {
            return Content("Aplicação validada com sucesso!");
        }
    }
}
