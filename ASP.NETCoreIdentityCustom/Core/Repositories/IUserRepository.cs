using Bornholm_Sleagts.Areas.Identity.Data;

namespace Bornholm_Sleagts.Core.Repositories
{
    public interface IUserRepository
    {
        ICollection<ApplicationUser> GetUsers();

        ApplicationUser GetUser(string id);

        ApplicationUser UpdateUser(ApplicationUser user);
        ApplicationUser AddUser(ApplicationUser user);

    }
}
