using IdentityService.Areas.Identity.Data;
using IdentityService.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IdentityService.Data;

public class IdentityServiceContext : IdentityDbContext<IdentityServiceUser, IdentityRole, string>
{
    public IdentityServiceContext(DbContextOptions<IdentityServiceContext> options)
        : base(options)
    {
    }
    public DbSet<VwUser> VwUsers { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
        builder.Entity<VwUser>(entity =>
        {
            entity.HasNoKey();
            entity.ToView("VwUsers");
        });
        builder.ApplyConfiguration(new ApplicationUserEntityConfiguration());
    }
    public class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<IdentityServiceUser>
    {
        public void Configure(EntityTypeBuilder<IdentityServiceUser> builder)
        {
            builder.Property(u => u.FirstName).HasMaxLength(255);
            builder.Property(u => u.LastName).HasMaxLength(255);
        }
    }

}
