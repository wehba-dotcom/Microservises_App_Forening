using Microsoft.AspNetCore.Identity;
using static IdentityUIService.Core.Constants;

namespace IdentityUIService.Seeds
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
