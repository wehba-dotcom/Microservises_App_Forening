using Microsoft.AspNetCore.Identity;

namespace IdentityService.Core.Interfaces
{
    public interface IRoleRepository
    {
        ICollection<IdentityRole> GetRoles();
    }
}
