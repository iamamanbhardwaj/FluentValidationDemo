using FluentValidationDemo.Model;
using Microsoft.AspNetCore.Mvc;

namespace FluentValidationDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }


        [Route("PostWithoutValidation")]
        [HttpPost]
        public WeatherForecastBase Post(WeatherForecastBase request)
        {
            return request;
        }
        
        //------------------------------------------------------------------------
        
        [Route("PostWithDataAnnotation")]
        [HttpPost]
        public WeatherForecast_Annotation PostWithDataAnnotation(WeatherForecast_Annotation request)
        {
            var sas = ModelState.IsValid;
            return request;
        }

        //------------------------------------------------------------------------

        [Route("PostWithValidataleObject")]
        [HttpPost]
        public WeatherForecast_ValidatableObject Postv4(WeatherForecast_ValidatableObject request)
        {
            return request;
        }

        //------------------------------------------------------------------------

        [Route("PostWithFluentValidation")]
        [HttpPost]
        public WeatherForecastv2 Postv2(WeatherForecastv2 request)
        {
            return request;
        }


    }
}