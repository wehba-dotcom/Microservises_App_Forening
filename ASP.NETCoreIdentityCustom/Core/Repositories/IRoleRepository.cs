using Bornholm_Sleagts.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;

namespace Bornholm_Sleagts.Core.Repositories
{
    public interface IRoleRepository
    {
        ICollection<IdentityRole> GetRoles();
    }
}
