using Microsoft.AspNetCore.Mvc;

namespace Lab01.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Lab01Controller : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<Lab01Controller> _logger;

        public Lab01Controller(ILogger<Lab01Controller> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [Route("AddHistory")]
        public string AddHistory()
        {
            _logger.LogInformation("AddHistory");

            try
            {
                var path = "/var/lab/logs";

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                var file = $"{path}/{DateTime.Now.ToString("ddMMyyyy_HH_mm_ss")}.log";

                System.IO.File.WriteAllText(file, "Log de pruebas");

                return "OK";
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error en AddHistory");
                return "ERROR";
            }
        }
         [Route("Version")]
        public string GetVersion()
        {
            _logger.LogInformation("Version");

            try
            {
                var path = "version";

               
                return "5.2";
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error en Version");
                return "ERROR";
            }
        }
    }
}
