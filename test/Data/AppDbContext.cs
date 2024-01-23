using Microsoft.EntityFrameworkCore;
using test.Models;

namespace test.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
           : base(options)
        {
        }
        public DbSet<Feallesbase> Feallesbases { get; set; }
    }
}
