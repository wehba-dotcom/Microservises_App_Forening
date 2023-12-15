using Microsoft.AspNetCore.Identity;
using static Bornholm_Sleagts.Core.Constants;

namespace Bornholm_Sleagts.Seeds
{
    public static class DefaultRole
    {
        public static async Task SeedAsync(RoleManager<IdentityRole> roleManager)
        {
            //if (!roleManager.Roles.Any())
            //{
            await roleManager.CreateAsync(new IdentityRole(Roles.Administrator.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Roles.Manager.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Roles.User.ToString()));
            //}
        }
    }
}
