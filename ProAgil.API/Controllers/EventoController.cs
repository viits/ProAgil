using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProAgil.Domain;
using ProAgil.Repository;

namespace ProAgil.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventoController : ControllerBase
    {
        private readonly IProAgilRepository repo;
        public EventoController(IProAgilRepository repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var results = await this.repo.GetAllEventosAsync(true);
                return Ok(results);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError);
            }

        }

        [HttpGet("{EventoId}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var results = await this.repo.GetEventoAsyncId(id, true);
                return Ok(results);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError);
            }

        }

        [HttpGet("getByTema/{tema}")]
        public async Task<IActionResult> Get(string tema)
        {
            try
            {
                var results = await this.repo.GetAllEventosAsyncTema(tema, true);
                return Ok(results);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError);
            }

        }

        //POST
        [HttpPost]
        public async Task<IActionResult> Post(Evento model)
        {
            try
            {
                this.repo.Add(model);
                if (await this.repo.SaveChangesAsync())
                {
                    return Created($"/api/evento{model.Id}", model);
                }
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError);
            }
            return BadRequest();

        }
        //Put
        [HttpPut]
        public async Task<IActionResult> Put(int id, Evento model)
        {
            try
            {
                var evento = await this.repo.GetEventoAsyncId(id, false);
                if (evento == null)
                {
                    return NotFound();
                }

                this.repo.Update(model);
                if (await this.repo.SaveChangesAsync())
                {
                    return Created($"/api/evento{model.Id}", model);
                }
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError);
            }
            return BadRequest();

        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var evento = await this.repo.GetEventoAsyncId(id,false);
                
                if (evento == null)
                {
                    return NotFound();
                }
                this.repo.Delete(evento);
                if (await this.repo.SaveChangesAsync())
                {
                    return Ok();
                }
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError);
            }
            return BadRequest();

        }

    }
}