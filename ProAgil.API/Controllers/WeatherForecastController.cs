using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProAgil.API.Data;
using ProAgil.API.Model;

namespace ProAgil.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]


    public class WeatherForecastController : ControllerBase
    {
        public readonly DataContext contexto;

        public WeatherForecastController(DataContext contexto)
        {
            this.contexto = contexto;
        }

        //api/weatherforescast
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try{
                var results = await this.contexto.Evento.ToListAsync();
                return Ok(results);
            }catch(System.Exception){
                return this.StatusCode(StatusCodes.Status500InternalServerError);
            }

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Evento>> Get(int id)
        {   
            try{
                var results = await this.contexto.Evento.FirstOrDefaultAsync(x => x.EventoId == id);;
                return Ok(results);
            }catch(System.Exception){
                return this.StatusCode(StatusCodes.Status500InternalServerError);
            }

        }

    }
}
