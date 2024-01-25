using IdentityService.Core.Interfaces;
using IdentityService.Data;
using Microsoft.AspNetCore.Identity;

namespace IdentityService.Repositories
{
    public class RoleRepository : IRoleRepository
    {


        private readonly IdentityServiceContext _context;
        public RoleRepository(IdentityServiceContext context)
        {
            _context = context;
        }
       
        public ICollection<IdentityRole> GetRoles()
        {
            return (ICollection<IdentityRole>)_context.Roles.ToList();
        }
    }
}
