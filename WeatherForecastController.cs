using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedProject.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MedProject.Controllers
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

        [HttpGet]
        public IEnumerable<Medecine> Get()
        {
            MedecineService md = new MedecineService();
            return md.GetMedecines();
        }

        [HttpPost]
        public bool Post(Medecine med)
        {
            MedecineService md = new MedecineService();
            var result = md.AddOrUpdateMedeCine(med);
            return result;
        }
    }
}
