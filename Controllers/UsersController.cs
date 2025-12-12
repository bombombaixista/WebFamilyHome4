using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebFamilyHome.Models;

namespace WebFamilyHome.Controllers
{
    [Authorize] // protege todas as actions por padrão
    public class UsersController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public UsersController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        // GET: /Users
        public IActionResult Index()
        {
            var users = _userManager.Users.ToList();
            return View(users);
        }

        // GET: /Users/Details/{id}
        public async Task<IActionResult> Details(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null) return NotFound();
            return View(user);
        }

        // GET: /Users/Create
        [AllowAnonymous] // libera acesso sem login
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Users/Create
        [HttpPost]
        [AllowAnonymous] // libera acesso sem login
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(User model, string password)
        {
            if (!ModelState.IsValid) return View(model);

            var result = await _userManager.CreateAsync(model, password);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                    ModelState.AddModelError(string.Empty, error.Description);
                return View(model);
            }

            // depois de cadastrar, volta para login
            return RedirectToAction("Login", "Account");
        }

        // GET: /Users/Edit/{id}
        public async Task<IActionResult> Edit(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null) return NotFound();
            return View(user);
        }

        // POST: /Users/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(User model)
        {
            var user = await _userManager.FindByIdAsync(model.Id);
            if (user == null) return NotFound();

            user.NomeCompleto = model.NomeCompleto;
            user.Email = model.Email;
            user.UserName = model.UserName;
            user.GroupId = model.GroupId;

            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                    ModelState.AddModelError(string.Empty, error.Description);
                return View(model);
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: /Users/Delete/{id}
        public async Task<IActionResult> Delete(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null) return NotFound();
            return View(user);
        }

        // POST: /Users/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null) return NotFound();

            var result = await _userManager.DeleteAsync(user);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                    ModelState.AddModelError(string.Empty, error.Description);
                return View("Delete", user);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
