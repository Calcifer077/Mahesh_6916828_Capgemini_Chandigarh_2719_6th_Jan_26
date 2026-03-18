var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

// Enable Session
builder.Services.AddSession();

var app = builder.Build();

app.UseStaticFiles();

app.UseRouting();

// Enable session middleware
app.UseSession();

app.MapDefaultControllerRoute();

app.Run();