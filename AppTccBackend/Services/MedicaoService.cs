using AppTccBackend.Data.Repositories;
using AppTccBackend.Data.Repositories.Interfaces;
using AppTccBackend.Models;
using AppTccBackend.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AppTccBackend.Services
{
    public class MedicaoService : IMedicaoService
    {
        private readonly IMedicaoRepository _medicaoRepository;
        private readonly ILogger<PacienteService> _logger;

        public MedicaoService(IMedicaoRepository medicaoRepository, ILogger<PacienteService> logger)
        {
            _medicaoRepository = medicaoRepository;
            _logger = logger;
        }

        public async Task<Medicao> AdicionarMedicao(Medicao medicao)
        {
            try
            {
                return await _medicaoRepository.AdicionarMedicao(medicao);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao adicionar medição");
                throw;
            }
        }

        public async Task<Medicao> AtualizarMedicao(Medicao medicao, Guid id)
        {
            try
            {
                return await _medicaoRepository.AtualizarMedicao(medicao, id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao atualizar medição");
                throw;
            }
        }

        public async Task<Medicao> ObterMedicaoPorId(Guid id)
        {
            try
            {
                return await _medicaoRepository.ObterMedicaoPorId(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao obter medição por ID");
                throw;
            }
        }

        public async Task<List<Medicao>> ObterMedicoes()
        {
            try
            {
                return await _medicaoRepository.ObterMedicoes();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao obter medição");
                throw;
            }
        }

        public async Task<List<Medicao>> ObterMedicoesDoPaciente(Guid pacienteId)
        {

            return await _medicaoRepository.ObterMedicoesDoPaciente(pacienteId);
        }

        public async Task<bool> RemoverMedicao(Guid id)
        {
            try
            {
                return await _medicaoRepository.RemoverMedicao(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao remover medição");
                throw;
            }
        }
    }
}
