using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;
using SolBank1.Models;

namespace SolBank1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InspiradosController : ControllerBase
    {
            private readonly InspiradosContext _inspiradosContext;
            public InspiradosController (InspiradosContext inspiradosContext)
        {
            _inspiradosContext = inspiradosContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Inspirados>>> getInspirados()
        {
            if (_inspiradosContext.Inspirado == null )
            {
                return NotFound();
            }
            return await _inspiradosContext.Inspirado.ToListAsync();
        }

        [HttpGet("{cedula}")]
        public async Task<ActionResult<Inspirados>> getInspirado(int cedula)
        {
            if (_inspiradosContext.Inspirado == null)
            {
                return NotFound();
            }
            var inspirado = await _inspiradosContext.Inspirado.FindAsync(cedula);
            if(inspirado == null)
            {
                return NotFound();
            }
            return inspirado;
        }

        [HttpPost]
        public async Task<ActionResult<Inspirados>> PostInspirado(Inspirados inspirado)
        {
            if (inspirado.fechaInscripcion == default(DateTime))
            {
                inspirado.fechaInscripcion = DateTime.Now;
            }

            _inspiradosContext.Inspirado.Add(inspirado);
            await _inspiradosContext.SaveChangesAsync();

            return CreatedAtAction(nameof(getInspirado), new { cedula = inspirado.cedula }, inspirado);
        }


        [HttpPut ("{cedula}")]
        public async Task<ActionResult> PutInspirado(int cedula, Inspirados inspirados)
        {
            if(cedula != inspirados.cedula)
            {
                return BadRequest();
            }
            _inspiradosContext.Entry(inspirados).State = EntityState.Modified;
            try
            {
                await _inspiradosContext.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException)
            {
                throw;
            }
            return Ok();
        }

        [HttpDelete("{cedula}")]
        public async Task<IActionResult> DeleteInspirado(int cedula)
        {
            if (_inspiradosContext.Inspirado == null)
            {
                return NotFound();
            }

            var inspirado = await _inspiradosContext.Inspirado.FindAsync(cedula);
            if (inspirado == null)
            {
                return NotFound();
            }

            _inspiradosContext.Inspirado.Remove(inspirado);
            await _inspiradosContext.SaveChangesAsync();

            return NoContent();
        }



    }
}

