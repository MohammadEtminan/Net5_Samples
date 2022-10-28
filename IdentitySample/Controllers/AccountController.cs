using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using IdentitySample.Models.DomainModels.AAADomainModels.Dtos;

namespace IdentitySample.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountController(SignInManager<IdentityUser> signInManager)
        {
            _signInManager = signInManager;
        }
        public IActionResult Login(string redirectUrl = "/")
        {
            return View(new LoginModel
            {
                RedirectUrl = redirectUrl,
            });
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(
                    loginModel.UserName,
                    loginModel.Password,
                    loginModel.RememberMe,
                    false);
                if (result.Succeeded) { return LocalRedirect(loginModel.RedirectUrl); }
                ModelState.AddModelError("", "Invalid UserName or Password!");

            }
            return View(loginModel);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Redirect("/");
        }
    }
}
