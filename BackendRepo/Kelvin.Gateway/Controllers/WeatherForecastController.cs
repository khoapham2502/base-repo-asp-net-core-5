using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kelvin.Core;
using Kelvin.Database;
using Kelvin.Core.IService;

namespace Kelvin.Gateway.Controllers
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
        private readonly IUnitOfWork _unitOfWork;
        private readonly INoteService _noteService;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IUnitOfWork iUnitOfWork, INoteService iNoteService)
        {
            _logger = logger;
            _unitOfWork = iUnitOfWork;
            _noteService = iNoteService;
        }

        [HttpGet]
        [Route("/something")]
        public async Task<IActionResult> something()
        {
            return Ok(await _noteService.GetByIdRange(1,1));
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
