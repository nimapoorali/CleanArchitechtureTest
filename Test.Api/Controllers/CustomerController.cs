using Microsoft.AspNetCore.Mvc;

namespace Test.Api.Controllers
{
    [ApiController]
    [Route("api/controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;

        public CustomerController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;

        }


    }
}
