using AppTccBackend.Models;

namespace AppTccBackend.Services.Interfaces
{
    public interface IPacienteService
    {
        Task<List<Paciente>> ObterPacientes();
        Task<Paciente> ObterPacientePorId(Guid id);
        Task<Paciente> AdicionarPaciente(Paciente paciente);
        Task<Paciente> AtualizarPaciente(Paciente paciente, Guid id);
        Task<bool> RemoverPaciente(Guid id);

        Task<List<Paciente>> ObterPacientesPorMedico(Guid medicoId);

    }
}
