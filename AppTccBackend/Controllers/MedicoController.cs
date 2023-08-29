using AppTccBackend.Models;
using AppTccBackend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AppTccBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MedicoController : ControllerBase
    {
        private readonly IMedicoService _medicoService;

        public MedicoController(IMedicoService medicoService)
        {
            _medicoService = medicoService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Medico>> Get(Guid id)
        {
            var medico = await _medicoService.ObterMedicoPorId(id);
            if (medico == null)
            {
                return NotFound();
            }

            return medico;
        }

        [HttpGet]
        public async Task<ActionResult<List<Medico>>> Get()
        {
            var medicos = await _medicoService.ObterMedicos();
            return medicos;
        }

        [HttpPost]
        public async Task<ActionResult<Medico>> Post(Medico medico)
        {
            try
            {
                var novoMedico = await _medicoService.AdicionarMedico(medico);
                return CreatedAtAction(nameof(Get), new { id = novoMedico.Id }, novoMedico);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, Medico medico)
        {
            if (id != medico.Id)
            {
                return BadRequest();
            }

            try
            {
                await _medicoService.AtualizarMedico(medico, id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _medicoService.RemoverMedico(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return NoContent();
        }
    }
}
