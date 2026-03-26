using Microsoft.AspNetCore.Identity;

namespace ECommerceApp.Data;

public static class SeedData
{
    public static async Task SeedAdminAsync(IServiceProvider serviceProvider)
    {
        var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();

        // Create Admin role if it doesn't exist
        if (!await roleManager.RoleExistsAsync("Admin"))
        {
            await roleManager.CreateAsync(new IdentityRole("Admin"));
        }

        // Create a default admin user
        var adminEmail = "admin@ecommerce.com";
        var adminUser = await userManager.FindByEmailAsync(adminEmail);

        if (adminUser == null)
        {
            adminUser = new IdentityUser
            {
                UserName = adminEmail,
                Email = adminEmail,
                EmailConfirmed = true
            };

            await userManager.CreateAsync(adminUser, "Admin@123456"); // change in production!
            await userManager.AddToRoleAsync(adminUser, "Admin");
        }
    }
}