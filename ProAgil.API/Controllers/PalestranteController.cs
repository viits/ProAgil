using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProAgil.Repository;

namespace ProAgil.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PalestranteController : ControllerBase
    {
        private readonly IProAgilRepository repo;
        public PalestranteController(IProAgilRepository repo)
        {
            this.repo = repo;
        }
        [HttpGet("nome/{name}")]
        public async Task<IActionResult> Get(string name)
        {
            try
            {
                var palestrante = await this.repo.GetAllPalestranteAsyncName(name, true);
                return Ok(palestrante);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
             try
            {
                var verifica = await this.repo.GetPalestranteIdAsync(id,false);
                return Ok(verifica);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError);
            }
        }


    }
}