using Microsoft.AspNetCore.Mvc;

namespace AppTccBackend.Controllers
{
    using AppTccBackend.Data;
    using AppTccBackend.Models;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    [ApiController]
    [Route("api/[controller]")]
    public class MedicoController : ControllerBase
    {
        private readonly ApiContexto _contexto;

        public MedicoController(ApiContexto contexto)
        {
            _contexto = contexto;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MedicoModel>>> ObterMedicos()
        {
            return await _contexto.Medico.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MedicoModel>> ObterMedicoPorId(int id)
        {
            var medico = await _contexto.Medico.FindAsync(id);

            if (medico == null)
            {
                return NotFound();
            }

            return medico;
        }

        [HttpPost]
        public async Task<ActionResult<MedicoModel>> AdicionarMedico([FromBody] MedicoModel medico)
         {
             _contexto.Medico.Add(medico);
             await _contexto.SaveChangesAsync();

             return CreatedAtAction(nameof(ObterMedicoPorId), new { id = medico.Id }, medico);
         }

         [HttpPut("{id}")]
         public async Task<IActionResult> AtualizarMedico(int id, [FromBody] MedicoModel medico)
         {
             if (id != medico.Id)
             {
                 return BadRequest();
             }

             _contexto.Entry(medico).State = EntityState.Modified;

             try
             {
                 await _contexto.SaveChangesAsync();
             }
             catch (DbUpdateConcurrencyException)
             {
                 if (!MedicoExists(id))
                 {
                     return NotFound();
                 }
                 else
                 {
                     throw;
                 }
             }

             return NoContent();
         }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoverMedico(int id)
        {
            var medico = await _contexto.Medico.FindAsync(id);
            if (medico == null)
            {
                return NotFound();
            }

            _contexto.Medico.Remove(medico);
            await _contexto.SaveChangesAsync();

            return NoContent();
        }

        private bool MedicoExists(int id)
           {
               return _contexto.Medico.Any(e => e.Id == id);
           }
       }
      
}