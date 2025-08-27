using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


var books = new List<(string Title, string Category)>
{
    ("C# Basics", "programming"),
    ("ASP.NET Core", "programming"),
    ("Best of Mozart", "music"),
    ("Guitar Lessons", "music")
};



app.Use(async (context, next) =>
{
    if (context.Request.Path.StartsWithSegments("/getbooks"))
    {
        var token = context.Request.Query["token"].ToString();

        if (token != "token12345")
        {
            context.Response.StatusCode = 401;
            await context.Response.WriteAsync("<h2>Unauthorized: Invalid or missing token</h2>");
            return; 
        }
    }

    await next();
});



app.MapGet("/allbooks", () =>
{
    return Results.Content(RenderBooks(books), "text/html");
});



app.MapGet("/getbooks", (HttpContext context) =>
{
    var category = context.Request.Query["category"].ToString();
    var filtered = books.Where(b =>
        b.Category.Equals(category, System.StringComparison.OrdinalIgnoreCase)).ToList();

    return Results.Content(RenderBooks(filtered), "text/html");
});


app.Run();



static string RenderBooks(IEnumerable<(string Title, string Category)> books)
{
    var html = "<table border='1' style='border-collapse: collapse;'>";
    html += "<tr><th>Title</th><th>Category</th></tr>";

    foreach (var b in books)
        html += $"<tr><td>{b.Title}</td><td>{b.Category}</td></tr>";

    html += "</table>";
    return html;
}
