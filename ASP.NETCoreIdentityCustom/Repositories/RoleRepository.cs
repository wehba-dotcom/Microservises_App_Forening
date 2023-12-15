using Bornholm_Sleagts.Areas.Identity.Data;
using Bornholm_Sleagts.Core.Repositories;
using Microsoft.AspNetCore.Identity;

namespace Bornholm_Sleagts.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly ApplicationDbContext _context;

        public RoleRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public ICollection<IdentityRole> GetRoles()
        {
            return _context.Roles.ToList();
        }
    }
}
