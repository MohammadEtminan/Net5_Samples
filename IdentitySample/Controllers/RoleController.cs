using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using IdentitySample.Models.DomainModels.AAADomainModels.Dtos;

namespace IdentitySample.Controllers
{
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            var roles = _roleManager.Roles.ToList();
            return View(roles);
        }

        [Authorize]
        public IActionResult RegisterRole()
        {
            return View(new CreateRoleModel());
        }
        
        [HttpPost]
        public async Task<IActionResult> RegisterRole(CreateRoleModel createRoleModel)
        {
            if (ModelState.IsValid)
            {
                var role = new IdentityRole
                {
                    Name = createRoleModel.RoleName


                };
                var result = await _roleManager.CreateAsync(role);
                if (result.Succeeded)
                {
                    TempData["Message"] = "Role Created";
                    return RedirectToAction("Index", "Roles");
                }
                else
                {
                    foreach (var e in result.Errors)
                    {
                        ModelState.AddModelError("", e.Description);
                    }
                }
            }
            return View(createRoleModel);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            var result = await _roleManager.DeleteAsync(role);
            if (result.Succeeded)
            {
                TempData["Message"] = "Role is Deleted";

            }
            else
            {
                TempData["Message"] = "Fail Delete";
            }
            return RedirectToAction("Index", "Roles");
        }
    }
}