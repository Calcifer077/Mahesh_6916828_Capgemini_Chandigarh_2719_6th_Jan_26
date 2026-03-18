using ProductManagement.Filters;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add<CustomExceptionFilter>();
});

builder.Services.AddScoped<LogActionFilter>();

var app = builder.Build();

app.UseRouting();

app.MapDefaultControllerRoute();

app.Run();