using Microsoft.EntityFrameworkCore;

public static class DbSeeder
{
    public static async Task SeedAsync(AppDbContext context)
    {
        await context.Database.MigrateAsync();

        if (await context.Users.AnyAsync())
            return;

        // USERS
        var alice = new User { Name = "Alice" };
        var bob = new User { Name = "Bob" };

        await context.Users.AddRangeAsync(alice, bob);
        await context.SaveChangesAsync(); // ✅ Save users FIRST so EF assigns their IDs

        // USER PROFILES (1-1) — now alice.Id and bob.Id are populated
        var profiles = new List<UserProfile>
        {
            new UserProfile { Address = "Delhi", UserId = alice.Id },
            new UserProfile { Address = "Mumbai", UserId = bob.Id },
        };
        await context.Profiles.AddRangeAsync(profiles);

        // ORDERS (1-M)
        var orders = new List<Order>
        {
            new Order { OrderDate = DateTime.UtcNow, UserId = alice.Id },
            new Order { OrderDate = DateTime.UtcNow.AddDays(-1), UserId = bob.Id },
        };
        await context.Orders.AddRangeAsync(orders);

        // PRODUCTS
        var laptop = new Product { Name = "Laptop" };
        var phone = new Product { Name = "Phone" };
        await context.Products.AddRangeAsync(laptop, phone);

        // CATEGORIES
        var electronics = new Category { Name = "Electronics" };
        var accessories = new Category { Name = "Accessories" };
        await context.Categories.AddRangeAsync(electronics, accessories);

        await context.SaveChangesAsync(); // ✅ Save products & categories so their IDs are assigned

        // MANY-TO-MANY (ProductCategory)
        var productCategories = new List<ProductCategory>
        {
            new ProductCategory { ProductId = laptop.Id, CategoryId = electronics.Id },
            new ProductCategory { ProductId = phone.Id, CategoryId = electronics.Id },
            new ProductCategory { ProductId = phone.Id, CategoryId = accessories.Id },
        };
        await context.ProductCategories.AddRangeAsync(productCategories);

        // REFRESH TOKENS
        var tokens = new List<RefreshToken>
        {
            new RefreshToken
            {
                Token = Guid.NewGuid().ToString(),
                ExpiryDate = DateTime.UtcNow.AddDays(7),
                UserId = alice.Id,
            },
        };
        await context.RefreshTokens.AddRangeAsync(tokens);

        await context.SaveChangesAsync(); // ✅ Final save
    }
}
