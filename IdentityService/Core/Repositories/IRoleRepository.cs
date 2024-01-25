using IdentityService.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;

namespace IdentityService.Core.Repositories
{
    public interface IRoleRepository
    {
        ICollection<IdentityRole> GetRoles();
    }
}
