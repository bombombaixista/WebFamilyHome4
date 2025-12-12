using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebFamilyHome.Models; // ajuste para o namespace correto

namespace WebFamilyHome.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        public LoginController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        // Modelo de request
        public class LoginRequest
        {
            public string Email { get; set; }
            public string Password { get; set; }
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null)
                return Unauthorized("Usuário não encontrado");

            var result = await _signInManager.PasswordSignInAsync(user, request.Password, false, false);

            if (result.Succeeded)
                return Ok("Login realizado com sucesso");

            return Unauthorized("Credenciais inválidas");
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] LoginRequest request)
        {
            var user = new IdentityUser { UserName = request.Email, Email = request.Email };
            var result = await _userManager.CreateAsync(user, request.Password);

            if (result.Succeeded)
                return Ok("Usuário registrado com sucesso");

            return BadRequest(result.Errors);
        }

        [HttpPost]
        [Route("logout")]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Ok("Logout realizado com sucesso");
        }
    }
}
