using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Mvc;


public class ISearchBody
{
    public string City { get; set; } = string.Empty;
}


namespace WeatherApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetWeather()
        {
            return Ok("hello world");
        }

        [HttpPost]
        public async Task<IActionResult> GetWeatherForCity(ISearchBody reqBody)
        {
            string url = "https://api.openweathermap.org/data/2.5";
            string cityInput = reqBody.City;
            var API_KEY = Environment.GetEnvironmentVariable("APIKEY");

            string queryURL = $"{url}/weather?q={cityInput}&appid={API_KEY}";

            HttpClient client = new HttpClient();

            HttpResponseMessage res = await client.GetAsync(queryURL);
            if (res.IsSuccessStatusCode)
            {
                var json = res.Content.ReadAsStringAsync();
                var data = json.Result;

                return Content(data, "application/json");
            }
            else
            {
                return StatusCode(500);
            }
        }
    }
}
