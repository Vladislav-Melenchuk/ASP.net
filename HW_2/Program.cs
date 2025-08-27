using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient();

var app = builder.Build();

app.MapGet("/weather", async (string city, IHttpClientFactory httpClientFactory) =>
{
    var apiKey = app.Configuration.GetValue<string>("WeatherApi:ApiKey");

    var http = httpClientFactory.CreateClient();
    var url = $"http://api.weatherapi.com/v1/current.json?key={apiKey}&q={city}&aqi=no";

    var response = await http.GetAsync(url);
    var json = await response.Content.ReadAsStringAsync();

    var data = System.Text.Json.JsonSerializer.Deserialize<WeatherResponse>(json);

    return Results.Ok(new
    {
        City = data.location.name,
        TemperatureC = data.current.temp_c,
        Condition = data.current.condition.text
    });
});

app.Run();

public class WeatherResponse
{
    public Location location { get; set; }
    public Current current { get; set; }
}

public class Location
{
    public string name { get; set; }
}

public class Current
{
    [JsonPropertyName("temp_c")]
    public double temp_c { get; set; }

    public Condition condition { get; set; }
}

public class Condition
{
    public string text { get; set; }
}
