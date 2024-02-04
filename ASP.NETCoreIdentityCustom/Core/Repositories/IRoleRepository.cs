using IdentityUIService.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;

namespace IdentityUIService.Core.Repositories
{
    public interface IRoleRepository
    {
        ICollection<IdentityRole> GetRoles();
    }
}
