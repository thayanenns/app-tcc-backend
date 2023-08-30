using AppTccBackend.Data;
using AppTccBackend.Models;
using AppTccBackend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AppTccBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PacienteController : ControllerBase
    {
        private readonly IPacienteService _pacienteService;

        public PacienteController(IPacienteService pacienteService)
        {
            _pacienteService = pacienteService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Paciente>> Get(Guid id)
        {
            var paciente = await _pacienteService.ObterPacientePorId(id);
            if (paciente == null)
            {
                return NotFound();
            }

            return paciente;
        }
        [HttpGet]
        public async Task<ActionResult<List<Paciente>>> Get(Guid? medicoId)
        {
            if (medicoId.HasValue)
            {
                var pacientesDoMedico = await _pacienteService.ObterPacientesDoMedico(medicoId.Value);
                return pacientesDoMedico;
            }
            else
            {
                var pacientes = await _pacienteService.ObterPacientes();
                return pacientes;
            }
        }


        [HttpPost]
        public async Task<ActionResult<Paciente>> Post(Paciente paciente)
        {
            try
            {
                var novoPaciente = await _pacienteService.AdicionarPaciente(paciente);
                return CreatedAtAction(nameof(Get), new { id = novoPaciente.Id }, novoPaciente);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, Paciente paciente)
        {
            if (id != paciente.Id)
            {
                return BadRequest();
            }

            try
            {
                await _pacienteService.AtualizarPaciente(paciente, id);
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
                await _pacienteService.RemoverPaciente(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return NoContent();
        }
    }
}
/*
private readonly PacienteService _pacienteService;

public PacienteController(PacienteService pacienteService)
{
    _pacienteService = pacienteService;
}

[HttpGet]
public IActionResult ObterPacientes()
{
    var pacientes = _pacienteService.ObterPacientes();
    return Ok(pacientes);
}

[HttpGet("{id}")]
public IActionResult ObterPacientePorId(Guid id)
{
    var paciente = _pacienteService.ObterPacientePorId(id);
    if (paciente == null)
    {
        return NotFound();
    }
    return Ok(paciente);
}

[HttpPost]
public IActionResult AdicionarPaciente(Paciente paciente)
{
    _pacienteService.AdicionarPaciente(paciente);
    return CreatedAtAction(nameof(ObterPacientePorId), new { id = paciente.Id }, paciente);
}

[HttpPut("{id}")]
public IActionResult AtualizarPaciente(Guid id, Paciente paciente)
{
    var existingPaciente = _pacienteService.ObterPacientePorId(id);
    if (existingPaciente == null)
    {
        return NotFound();
    }
    _pacienteService.AtualizarPaciente(paciente);
    return NoContent();
}

[HttpDelete("{id}")]
public IActionResult RemoverPaciente(Guid id)
{
    var existingPaciente = _pacienteService.ObterPacientePorId(id);
    if (existingPaciente == null)
    {
        return NotFound();
    }
    _pacienteService.RemoverPaciente(id);
    return NoContent();
}
}


*/



