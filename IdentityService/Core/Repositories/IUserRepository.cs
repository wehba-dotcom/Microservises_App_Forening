using IdentityService.Areas.Identity.Data;

namespace IdentityService.Core.Repositories
{
    public interface IUserRepository
    {
        ICollection<IdentityServiceUser> GetUsers();

        IdentityServiceUser GetUser(string id);

        IdentityServiceUser UpdateUser(IdentityServiceUser user);
        IdentityServiceUser AddUser(IdentityServiceUser user);

    }
}
