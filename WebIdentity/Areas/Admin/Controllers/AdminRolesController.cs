using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using WebIdentity.Areas.Admin.Models;

namespace WebIdentity.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminRolesController : Controller
    {
        private RoleManager<IdentityRole> _roleManager;
        private UserManager<IdentityUser> _userManager;

        public AdminRolesController(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public IActionResult Index() => View(_roleManager.Roles);

        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create([Required] IdentityRole role)
        {
            if (ModelState.IsValid)
            {
                IdentityResult result = await _roleManager.CreateAsync(role);
                if (result.Succeeded)
                    return RedirectToAction("Index");

                else  Erros(result);
            }
            return View(role);
        }

        [HttpGet]
        public async Task<IActionResult> Upadate(string id)
        {
            IdentityRole role = await _roleManager.FindByIdAsync(id);

            List<IdentityUser> menbers = new List<IdentityUser>();
            List<IdentityUser> nomMenbers = new List<IdentityUser>();

            foreach (IdentityUser user in _userManager.Users)
            {
                var list = await _userManager.IsInRoleAsync(user, role.Name) ? menbers : nomMenbers;

                list.Add(user);
            }

            return View(new RoleEdit
            {
                role = role,
                Members = menbers,
                NonMembers = nomMenbers
            });
        }

        [HttpPost]
        public async Task<IActionResult> Upadate(RoleModification model)
        {
            if (ModelState.IsValid)
            {
                foreach (string userId in model.AddIds ?? new string[] { })
                {
                    IdentityUser user = await _userManager.FindByIdAsync(userId);
                    if (user != null)
                    {
                        var result = await _userManager.AddToRoleAsync(user, model.RoleName);
                        if (!result.Succeeded)
                            Erros(result);
                    }
                }
                foreach ( string userId in model.DeleteIds ?? new string[] {})
                {
                    IdentityUser user = await _userManager.FindByIdAsync(userId);

                    if(user != null)
                    {
                        var result = await _userManager.RemoveFromRoleAsync(user, model.RoleName);
                        if(!result.Succeeded)
                            Erros(result);
                    }
                }
            }
            if (ModelState.IsValid)
                return RedirectToAction(nameof(Index));
            else
                return await Upadate(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            IdentityRole role = await _roleManager.FindByIdAsync(id);

            if (role != null)
            {
                ModelState.AddModelError("", "Role não encontrada");
                return View("Index",_roleManager.Roles);
            }

            return View(role);
        }

        [HttpPost]
        public async Task<IActionResult>DeleteConfirmed(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);

            if (role != null)
            {
                IdentityResult result = await _roleManager.DeleteAsync(role);

                if (!result.Succeeded)
                    return RedirectToAction(nameof(Index));
                else
                    Erros(result);
            }
            else
            {
                ModelState.AddModelError("", "Role não encontrado");
            }
            return View("Index",_roleManager.Roles);
        }

        private void Erros(IdentityResult result) 
        {
            foreach(IdentityError error in result.Errors) 
                ModelState.AddModelError("",error.Description);
        }
    }
}
