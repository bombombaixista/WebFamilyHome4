using Microsoft.AspNetCore.Mvc;

namespace WebFamilyHome.Controllers
{
    public class ValidateController : Controller
    {
        public IActionResult Index()
        {
            return Json(new { status = "ok", message = "API validada com sucesso!" });
        }
    }
}
