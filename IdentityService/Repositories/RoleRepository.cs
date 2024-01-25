using IdentityService.Core.Repositories;
using IdentityService.Data;
using Microsoft.AspNetCore.Identity;

namespace IdentityService.Repositories
{
    public class RoleRepository:IRoleRepository
    {
        private readonly IdentityServiceContext _context;
        public RoleRepository(IdentityServiceContext context)
        {
            _context = context;
        }
        public ICollection<IdentityRole> GetRoles()
        {
            return _context.Roles.ToList();
        }

    }
}
