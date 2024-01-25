using IdentityService.Areas.Identity.Data;
using IdentityService.Core.Interfaces;
using IdentityService.Data;

namespace IdentityService.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IdentityServiceContext _context;

        public UserRepository(IdentityServiceContext context)
        {
            _context = context;
        }

        public IdentityServiceUser AddUser(IdentityServiceUser user)
        {
             _context.Users.Add(user);
            return user;
        }

        public IdentityServiceUser GetUser(string id)
        {
            return _context.Users.FirstOrDefault(u => u.Id == id);
        }

        public ICollection<IdentityServiceUser> GetUsers()
        {
            return _context.Users.ToList();
        }

        public IdentityServiceUser UpdateUser(IdentityServiceUser user)
        {
            _context.Update(user);
            _context.SaveChanges();

            return user;
        }
    }
}
