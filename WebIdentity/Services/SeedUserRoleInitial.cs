
using Microsoft.AspNetCore.Identity;

namespace WebIdentity.Services
{
    public class SeedUserRoleInitial : ISeedUserRoleInitial
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public SeedUserRoleInitial(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task SeendRoleAsync()
        {
            if (await _roleManager.RoleExistsAsync("User"))
            {
                IdentityRole role = new IdentityRole();

                role.Name = "User";
                role.NormalizedName = "USER";
                role.ConcurrencyStamp = Guid.NewGuid().ToString();

                IdentityResult identityResult = await _roleManager.CreateAsync(role);
            }


            if (await _roleManager.RoleExistsAsync("admin"))
            {
                IdentityRole role = new IdentityRole();

                role.Name = "admin";
                role.NormalizedName = "ADMIN";
                role.ConcurrencyStamp = Guid.NewGuid().ToString();

                IdentityResult identityResult = await _roleManager.CreateAsync(role);
            }

        }

        public async Task SeendUserAsync()
        {
            if(await _userManager.FindByEmailAsync("admin@localhost") == null)
            {
                IdentityUser user = new IdentityUser();
                user.UserName= "admin";
                user.Email = "admin@localhost";
                user.NormalizedUserName = "admin";
                user.NormalizedEmail = "admin@localhost";
                user.EmailConfirmed = true;
                user.LockoutEnabled = true;
                user.SecurityStamp = Guid.NewGuid().ToString();

                IdentityResult identityResult = await _userManager.CreateAsync(user,"Numsey#2024");

                if (identityResult.Succeeded)
                    await _userManager.AddToRoleAsync(user, "Admin");
            }
        }
    }
}
