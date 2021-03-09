using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using ProAgil.Domain;
using ProAgil.Repository;

namespace ProAgil.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]


    public class WeatherForecastController : ControllerBase
    {
        public readonly ProAgilContext contexto;

        public WeatherForecastController(ProAgilContext contexto)
        {
            this.contexto = contexto;
        }

        //api/weatherforescast
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try{
                var results = await this.contexto.Eventos.ToListAsync();
                return Ok(results);
            }catch(System.Exception){
                return this.StatusCode(StatusCodes.Status500InternalServerError);
            }

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Evento>> Get(int id)
        {   
            try{
                var results = await this.contexto.Eventos.FirstOrDefaultAsync(x => x.Id == id);;
                return Ok(results);
            }catch(System.Exception){
                return this.StatusCode(StatusCodes.Status500InternalServerError);
            }

        }

    }
}
