using Microsoft.AspNetCore.Identity;

namespace WebIdentity.Areas.Admin.Models
{
    public class RoleEdit
    {
        public IdentityRole? role { get; set; }
        public IEnumerable<IdentityUser>? Members { get; set; }

        public IEnumerable<IdentityUser>?NonMembers { get; set; }
    }
}
