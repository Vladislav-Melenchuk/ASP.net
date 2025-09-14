var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.UseStaticFiles();

app.MapGet("/", async context =>
{
    context.Response.Redirect("/index.html");
});

app.MapPost("/upload", async (HttpRequest request, IWebHostEnvironment env) =>
{
    var form = await request.ReadFormAsync();
    var file = form.Files.FirstOrDefault();

    if (file == null || file.Length == 0)
    {
        return Results.BadRequest("Файл не найден.");
    }

    var uploadPath = Path.Combine(env.WebRootPath ?? "wwwroot", "uploads");
    if (!Directory.Exists(uploadPath))
    {
        Directory.CreateDirectory(uploadPath);
    }

    var fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
    var filePath = Path.Combine(uploadPath, fileName);

    using var ms = new MemoryStream();
    await file.CopyToAsync(ms);
    File.WriteAllBytes(filePath, ms.ToArray());

    var fileUrl = $"/uploads/{fileName}";
    return Results.Ok(new { Url = fileUrl });
});

app.Run();
