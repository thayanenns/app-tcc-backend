using AppTccBackend.Data.Repositories.Interfaces;
using AppTccBackend.Enum;
using AppTccBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace AppTccBackend.Data.Repositories
{
    public class PacienteRepository : IPacienteRepository
    {
        private readonly ApiContexto _context;

        public PacienteRepository(ApiContexto context)
        {
            _context = context;
        }

        public async Task<List<Paciente>> ObterPacientes()
        {
            return await _context.Usuarios.OfType<Paciente>().ToListAsync();
        }

        public async Task<Paciente> ObterPacientePorId(Guid id)
        {
            return await _context.Usuarios.OfType<Paciente>().FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Paciente> AdicionarPaciente(Paciente paciente)
        {
            await _context.Usuarios.AddAsync(paciente);
            await _context.SaveChangesAsync();
            return paciente;
        }

        public async Task<Paciente> AtualizarPaciente(Paciente paciente, Guid id)
        {
            var pacienteBuscado = await ObterPacientePorId(id);
            if (pacienteBuscado == null)
            {
                throw new Exception("Paciente não encontrado no banco");
            }

            // Atualize as propriedades necessárias
            pacienteBuscado.Nome = paciente.Nome;
            pacienteBuscado.Telefone = paciente.Telefone;

            _context.Usuarios.Update(pacienteBuscado);
            await _context.SaveChangesAsync();

            return pacienteBuscado;
        }

        public async Task<bool> RemoverPaciente(Guid id)
        {
            var pacienteBuscado = await ObterPacientePorId(id);
            if (pacienteBuscado == null)
            {
                throw new Exception("Paciente não encontrado no banco");
            }

            _context.Usuarios.Remove(pacienteBuscado);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<List<Paciente>> ObterPacientesDoMedico(Guid medicoId)
        {
            var pacientesDoMedico = await _context.Usuarios
                .OfType<Paciente>() // Filtrar apenas os registros que são do tipo Paciente
                .Where(p => p.MedicoId == medicoId) // Filtrar por médicoId
                .ToListAsync();

            return pacientesDoMedico;
        }




    }

}
