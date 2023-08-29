using AppTccBackend.Models;

namespace AppTccBackend.Services.Interfaces
{
    public interface IMedicoService
    {
        Task<List<Medico>> ObterMedicos();
        Task<Medico> ObterMedicoPorId(Guid id);
        Task<Medico> AdicionarMedico(Medico medico);
        Task<Medico> AtualizarMedico(Medico medico, Guid id);
        Task<bool> RemoverMedico(Guid id);
    }
}
