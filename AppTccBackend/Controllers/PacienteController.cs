using AppTccBackend.Data;
using AppTccBackend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class PacienteController : ControllerBase
{
    private readonly ApiContexto _contexto;

    public PacienteController(ApiContexto contexto)
    {
        _contexto = contexto;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<PacienteModel>>> ObterPacientes()
    {
        return await _contexto.Paciente.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<PacienteModel>> ObterPacientePorId(int id)
    {
        var paciente = await _contexto.Paciente.FindAsync(id);

        if (paciente == null)
        {
            return NotFound();
        }

        return paciente;
    }

    [HttpPost]
    public async Task<ActionResult<PacienteModel>> AdicionarPaciente([FromBody] PacienteModel paciente)
    {
        _contexto.Paciente.Add(paciente);
        await _contexto.SaveChangesAsync();

        return CreatedAtAction(nameof(ObterPacientePorId), new { id = paciente.Id }, paciente);
    }

    [HttpPut("{id}")]
    public IActionResult AtualizarPaciente(int id, [FromBody] PacienteModel pacienteDados)
    {
        var paciente = _contexto.Paciente.FirstOrDefault(p => p.Id == id);
        if (paciente == null)
        {
            return NotFound();
        }

        // Atualize as propriedades relevantes do paciente com os dados fornecidos
        paciente.Nome = pacienteDados.Nome;
        paciente.Telefone = pacienteDados.Telefone;

        _contexto.SaveChanges();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> RemoverPaciente(int id)
    {
        var paciente = await _contexto.Paciente.FindAsync(id);
        if (paciente == null)
        {
            return NotFound();
        }

        _contexto.Paciente.Remove(paciente);
        await _contexto.SaveChangesAsync();

        return NoContent();
    }
    private bool PacienteExists(int id)
    {
        return _contexto.Paciente.Any(e => e.Id == id);
    }
}


