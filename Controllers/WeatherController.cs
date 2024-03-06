using Microsoft.AspNetCore.Mvc;

namespace WeatherApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherController: ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetWeather()
        {
            return Ok("hello world");
        }
    }
}
