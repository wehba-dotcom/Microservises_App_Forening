using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FeallesMvcService.Models;

namespace FeallesMvcService.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext (DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<FeallesMvcService.Models.Feallesbase> Feallesbases { get; set; } = default!;
    }
}
