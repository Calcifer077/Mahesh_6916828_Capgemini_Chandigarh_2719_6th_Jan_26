using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using ECommerceApp.Data;

var builder = WebApplication.CreateBuilder(args);

// Database
builder.Services.AddDbContext<ECommerceAppContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ECommerceAppContext")
        ?? throw new InvalidOperationException("Connection string 'ECommerceAppContext' not found.")));

// ✅ Identity registration (was missing entirely)
builder.Services.AddDefaultIdentity<IdentityUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
})
.AddRoles<IdentityRole>()
.AddEntityFrameworkStores<ECommerceAppContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();       // ✅ use this instead of MapStaticAssets (see note below)
app.UseRouting();
app.UseAuthentication();    // ✅ must be before UseAuthorization
app.UseAuthorization();

app.MapStaticAssets();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();
app.MapRazorPages();        // ✅ required for Identity login/register pages

// Seed admin role and user
using (var scope = app.Services.CreateScope())
{
    await SeedData.SeedAdminAsync(scope.ServiceProvider);
}

app.Run();