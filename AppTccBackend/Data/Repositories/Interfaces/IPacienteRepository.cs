using AppTccBackend.Models;

namespace AppTccBackend.Data.Repositories.Interfaces
{
    public interface IPacienteRepository
    {
        Task<List<Paciente>> ObterPacientes();
        Task<Paciente> ObterPacientePorId(Guid id);
        Task<Paciente> AdicionarPaciente(Paciente paciente);
        Task<Paciente> AtualizarPaciente(Paciente paciente, Guid id);
        Task<bool> RemoverPaciente(Guid id);

        Task<List<Paciente>> ObterPacientesDoMedico(Guid medicoId);

    }
}
