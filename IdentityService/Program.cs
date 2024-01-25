using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using IdentityService.Areas.Identity.Data;
using IdentityService.Core;
using IdentityService.Core.Repositories;
using IdentityService.Repositories;
using System.Drawing;
using IdentityService.Data;
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("IdentityServiceContextConnection") ?? throw new InvalidOperationException("Connection string 'IdentityServiceContextConnection' not found.");

builder.Services.AddDbContext<IdentityServiceContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<IdentityServiceUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<IdentityServiceContext>()
    .AddRoles<IdentityRole>();

// Add services to the container.
builder.Services.AddControllersWithViews();

#region Authorization

AddAuthorizationPolicies();

#endregion

AddScoped();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//app.UseHttpsRedirection();
app.UseRouting();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

using var Scope = app.Services.CreateScope();
var services = Scope.ServiceProvider;
//try
//{
//    var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
//    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

//    await DefaultRole.SeedAsync(roleManager);
//    await DefaultUser.SeedAdminAsync(userManager, roleManager);
//    await DefaultUser.SeedBasicUserAsync(userManager, roleManager);
//}
//catch (Exception) { throw; }


app.Run();


void AddAuthorizationPolicies()
{
    builder.Services.AddAuthorization(options =>
    {
        options.AddPolicy("EmployeeOnly", policy => policy.RequireClaim("EmployeeNumber"));
    });

    builder.Services.AddAuthorization(options =>
    {
        options.AddPolicy(Constants.Policies.RequireAdmin, policy => policy.RequireRole(Constants.Roles.Administrator));
        options.AddPolicy(Constants.Policies.RequireManager, policy => policy.RequireRole(Constants.Roles.Manager));
    });
}

void AddScoped()
{
    builder.Services.AddScoped<IUserRepository, IUserRepository>();
    builder.Services.AddScoped<IRoleRepository, RoleRepository>();
    builder.Services.AddScoped<IUnitOfWork, IUnitOfWork>();
}