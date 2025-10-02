using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace HW_WebAPI.Controllers
{
    public class WeatherController : Controller
    {
        private readonly HttpClient _httpClient;

        public WeatherController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(string city)
        {
            if (string.IsNullOrWhiteSpace(city))
            {
                ViewBag.Error = "Введите название города";
                return View();
            }

            string apiKey = "1934bf8b06c8199618102db187b99e25"; 
            string url = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={apiKey}&units=metric&lang=ru";

            try
            {
                var response = await _httpClient.GetAsync(url);

                if (!response.IsSuccessStatusCode)
                {
                    ViewBag.Error = "Город не найден или ошибка API";
                    return View();
                }

                var json = await response.Content.ReadAsStringAsync();
                var data = JObject.Parse(json);

                ViewBag.City = (string)data["name"];
                ViewBag.Country = (string)data["sys"]["country"];
                ViewBag.Temp = (double)data["main"]["temp"];
                ViewBag.FeelsLike = (double)data["main"]["feels_like"];
                ViewBag.Weather = (string)data["weather"][0]["description"];
                ViewBag.Humidity = (int)data["main"]["humidity"];
                ViewBag.Wind = (double)data["wind"]["speed"];
            }
            catch
            {
                ViewBag.Error = "Ошибка получения данных";
            }

            return View();
        }
    }
}
