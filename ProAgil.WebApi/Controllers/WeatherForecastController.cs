using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProAgil.WebApi.Model;

namespace ProAgil.WebApi.Controllers
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
        public IEnumerable<Evento> Get()
        {
            return new Evento[]
            {
                new Evento()
                {
                    Eventoid = 1,
                    Tema = "Angular e .NET CORE",
                    Local = "Sao Paulo",
                    Lote = " 1 lote",
                    QntdPessoas = 250,
                    DataEvento = DateTime.Now.AddDays(2).ToString("dd/MM/yyyy")
                },
                 new Evento()
                {
                    Eventoid = 2,
                    Tema = "Angular e suas novidades",
                    Local = "Rio de Janeiro",
                    Lote = " 2 lote",
                    QntdPessoas = 200,
                    DataEvento = DateTime.Now.AddDays(3).ToString("dd/MM/yyyy")
                },

            };
        }

        [HttpGet]
         public ActionResult<Evento> Get(int id)
        {
            return new Evento[]
          {
                new Evento()
                {
                    Eventoid = 1,
                    Tema = "Angular e .NET CORE",
                    Local = "Sao Paulo",
                    Lote = " 1 lote",
                    QntdPessoas = 250,
                    DataEvento = DateTime.Now.AddDays(2).ToString("dd/MM/yyyy")
                },
                 new Evento()
                {
                    Eventoid = 2,
                    Tema = "Angular e suas novidades",
                    Local = "Rio de Janeiro",
                    Lote = " 2 lote",
                    QntdPessoas = 200,
                    DataEvento = DateTime.Now.AddDays(3).ToString("dd/MM/yyyy")
                },

          }.FirstOrDefault(x => x.Eventoid == id);
        }
    }
}
