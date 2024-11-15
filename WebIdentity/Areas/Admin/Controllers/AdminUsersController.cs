using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WebIdentity.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminUsersController : Controller
    {
        private  readonly UserManager<IdentityUser> _userManager;

        public AdminUsersController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult index()
        {
            var user = _userManager.Users;
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult>DeletarUser(string Id)
        {
            var user = await _userManager.FindByNameAsync(Id);

            if (user == null)
            {
                ViewBag.ErrorMennssage = $"Usuario com id ={Id} não foi encontrodo";
                return View("NotFound");
            }
            else
            {
                var result = await _userManager.DeleteAsync(user);

                if (result.Succeeded) 
                    return RedirectToAction("Index");

                foreach (var error in result.Errors)
                    ModelState.AddModelError("", error.Description);

                return View("Index");
            }
        }
    }
}
