var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthorization();

var app = builder.Build();

app.UseExceptionHandler("/error");
app.UseHttpsRedirection();
app.UseRouting();

app.MapGet("/", () => "Hello from the middleware;");
app.MapGet("/error", () => "Hello");

app.Run();
