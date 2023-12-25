using WebApplication1.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.Models;

namespace WebApplication1.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    public DbSet<Feallesbase> Feallesbases { get; set; }
}

// protected override void OnModelCreating(ModelBuilder builder)
//{
//    base.OnModelCreating(builder);
//    // Customize the ASP.NET Identity model and override the defaults if needed.
//    // For example, you can rename the ASP.NET Identity table names and more.
//    // Add your customizations after calling base.OnModelCreating(builder);
//    builder.Entity<VwUser>(entity =>
//    {
//        entity.HasNoKey();
//        entity.ToView("VwUsers");
//    });
//    builder.ApplyConfiguration(new ApplicationUserEntityConfiguration());
//}


//public class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<ApplicationUser>
//{
//    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
//    {
//        builder.Property(u => u.FirstName).HasMaxLength(255);
//        builder.Property(u => u.LastName).HasMaxLength(255);
//    }
//}
