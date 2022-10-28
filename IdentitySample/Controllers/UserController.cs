using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using IdentitySample.Models.DomainModels.AAADomainModels.Dtos;

namespace IdentitySample.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private UserManager<IdentityUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;

        public UserController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            var users = _userManager.Users.ToList();
            return View(users);
        }

        public IActionResult RegisterUser()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegisterUser(CreateUserModel createUserModel)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser
                {
                    UserName = createUserModel.UserName,
                    Email = createUserModel.Email

                };
                var result = await _userManager.CreateAsync(user, createUserModel.Password);
                if (result.Succeeded)
                {
                    TempData["Message"] = "User Created";
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    foreach (var e in result.Errors)
                    {
                        ModelState.AddModelError("", e.Description);
                    }
                }
            }
            return View(createUserModel);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            var result = await _userManager.DeleteAsync(user);
            if (result.Succeeded)
            {
                TempData["Message"] = "User is Deleted";

            }
            else
            {
                TempData["Message"] = "Fail Delete";
            }
            return RedirectToAction("Index", "Users");
        }

        public async Task<IActionResult> EditUserRoles(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            var userRoles = await _userManager.GetRolesAsync(user);
            var roles = _roleManager.Roles.ToList();
            var model = new EditUserRoles()
            {
                UserName = user.UserName,
                UserId = user.Id,
                Roles = roles,
                UserRoles = userRoles.ToList()

            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> EditUserRoles(string userId, List<string> roles)
        {
            var user = await _userManager.FindByIdAsync(userId);
            var currentRoles = await _userManager.GetRolesAsync(user);
            foreach (var item in currentRoles)
            {
                if (!roles.Any(c => c == item))
                {
                    var removeRoleResult = await _userManager.RemoveFromRoleAsync(user, item);
                }
            }
            foreach (var item in roles)
            {
                var isInRole = await _userManager.IsInRoleAsync(user, item);
                if (!isInRole)
                {
                    var addToRoleResult = await _userManager.AddToRoleAsync(user, item);
                }
            }
            return RedirectToAction("Index", "User");
        }
    }
}
