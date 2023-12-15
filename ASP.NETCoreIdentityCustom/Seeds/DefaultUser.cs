using Bornholm_Sleagts.Areas.Identity.Data;
using Bornholm_Sleagts.Core;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using static Bornholm_Sleagts.Core.Constants;
using static Bornholm_Sleagts.Helper;
namespace Bornholm_Sleagts.Seeds
{
    public static class DefaultUser
    {


        //public static async Task SeedAdminAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        //{
        //    var DefultUser = new ApplicationUser
        //    {

        //        FirstName = FirstNameAdmin,
        //        LastName = LastNameAdmin,
        //        Email = EmailAdmin,
        //        EmailConfirmed = true
        //    };

        //    var user = await userManager.FindByEmailAsync(DefultUser.Email);
        //    if (user == null)
        //    {
        //        await userManager.CreateAsync(DefultUser, PassowrdAdmin);
        //        await userManager.AddToRolesAsync(DefultUser, new List<string> { Core.Constants.Roles.Administrator.ToString() });
        //    }

        //    await roleManager.SeedClaimsAsync();
        //}
        public static async Task SeedBasicUserAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            var DefultUser = new ApplicationUser
            {
                FirstName = LastNameBasic,
                LastName = LastNameBasic,
                Email = EmailBasic,
                EmailConfirmed = true
            };

            var user = userManager.FindByEmailAsync(DefultUser.Email);
            if (user.Result == null)
            {
                await userManager.CreateAsync(DefultUser, PasswordBasic);
                await userManager.AddToRolesAsync(DefultUser, new List<string> {Roles.User.ToString() });
            }
        }

        public static async Task SeedAdminAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            var DefaultUser = new ApplicationUser
            {
                FirstName = FirstNameAdmin,
                LastName = LastNameAdmin,
                Email = EmailAdmin,
                EmailConfirmed = true
            };

            var user = await userManager.FindByEmailAsync(DefaultUser.Email);
            if (user == null)
            {
                await userManager.CreateAsync(DefaultUser, Password);
                await userManager.AddToRolesAsync(DefaultUser, new List<string> {Roles.Administrator.ToString() });
            }

            await roleManager.SeedClaimsAsync();
        }


        public static async Task SeedClaimsAsync(this RoleManager<IdentityRole> roleManager)
        {
            var adminRole = await roleManager.FindByNameAsync(Roles.Manager.ToString());
            var modules = Enum.GetValues(typeof(PermissionModuleName));
            foreach (var module in modules)
                await roleManager.AddPermissionClaims(adminRole, module.ToString());
        }

        public static async Task AddPermissionClaims(this RoleManager<IdentityRole> roleManager, IdentityRole role, string module)
        {
            var allClaims = await roleManager.GetClaimsAsync(role);
            var allPermissions = Permissions.GeneratePermissionsFromModule(module);

            foreach (var permission in allPermissions)
                if (allClaims.Any(x => x.Type == Permission && x.Value == permission))
                    await roleManager.AddClaimAsync(role, new Claim(Permission, permission));
        }
    }
}