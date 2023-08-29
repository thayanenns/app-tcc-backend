using AppTccBackend.Models;

namespace AppTccBackend.Data.Repositories.Interfaces
{
    public interface IMedicoRepository
    {
        Task<List<Medico>> ObterMedicos();
        Task<Medico> ObterMedicoPorId(Guid id);
        Task<Medico> AdicionarMedico(Medico medico);
        Task<Medico> AtualizarMedico(Medico medico, Guid id);
        Task<bool> RemoverMedico(Guid id);
    }
}
