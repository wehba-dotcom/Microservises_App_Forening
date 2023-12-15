using Bornholm_Sleagts.Core.Repositories;

namespace Bornholm_Sleagts.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public IUserRepository User { get; }
        public IRoleRepository Role { get; }

        public UnitOfWork(IUserRepository user, IRoleRepository role)
        {
            User = user;
            Role = role;
        }
    }
}
