﻿using IdentityUIService.Areas.Identity.Data;
using IdentityUIService.Core.Repositories;
using Microsoft.AspNetCore.Identity;

namespace IdentityUIService.Repositories
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
