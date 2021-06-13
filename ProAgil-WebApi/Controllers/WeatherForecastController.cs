using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProAgil.WebApi.Model;
using ProAgil_WebApi.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProAgil_WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        public DataContext _context { get; }
        public WeatherForecastController(DataContext context)
        {
            _context = context;

        }      


        // GET api/values
        public async Task<IActionResult> Get()
        {

            try
            {   
                var results = await _context.Eventos.ToListAsync();
                return Ok(results);

            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco Dados Falhou");                
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {

            try
            {   
                var results = await _context.Eventos.FirstOrDefaultAsync(x => x.Eventoid == id);
                return Ok(results);

            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco Dados Falhou");                
            }
        }


       

    }
}
