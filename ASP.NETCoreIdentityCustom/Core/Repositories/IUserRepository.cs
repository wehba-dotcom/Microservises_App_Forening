using IdentityUIService.Areas.Identity.Data;

namespace IdentityUIService.Core.Repositories
{
    public interface IUserRepository
    {
        ICollection<ApplicationUser> GetUsers();

        ApplicationUser GetUser(string id);

        ApplicationUser UpdateUser(ApplicationUser user);
        ApplicationUser AddUser(ApplicationUser user);

    }
}
