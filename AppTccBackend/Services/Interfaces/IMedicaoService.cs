using AppTccBackend.Models;

namespace AppTccBackend.Services.Interfaces
{
    public interface IMedicaoService
    {
        Task<List<Medicao>> ObterMedicoes();
        Task<Medicao> ObterMedicaoPorId(Guid id);
        Task<Medicao> AdicionarMedicao(Medicao medicao);
        Task<Medicao> AtualizarMedicao(Medicao medicao, Guid id);
        Task<bool> RemoverMedicao(Guid id);

        Task<List<Medicao>> ObterMedicoesDoPaciente(Guid pacienteId);

    }
}
