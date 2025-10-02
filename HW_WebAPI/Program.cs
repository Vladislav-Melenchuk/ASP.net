var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient();

builder.Services.AddOpenApi();

var app = builder.Build();


app.UseHttpsRedirection();

app.UseAuthorization();



app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Weather}/{action=Index}/{id?}");

app.Run();
