using AppTccBackend.Data.Repositories.Interfaces;
using AppTccBackend.Models;
using AppTccBackend.Services.Interfaces;

namespace AppTccBackend.Services
{
    public class MedicoService : IMedicoService
    {
        private readonly IMedicoRepository _medicoRepository;
        private readonly ILogger<MedicoService> _logger;

        public MedicoService(IMedicoRepository medicoRepository, ILogger<MedicoService> logger)
        {
            _medicoRepository = medicoRepository;
            _logger = logger;
        }

        public async Task<List<Medico>> ObterMedicos()
        {
            try
            {
                return await _medicoRepository.ObterMedicos();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao obter médicos");
                throw;
            }
        }

        public async Task<Medico> ObterMedicoPorId(Guid id)
        {
            try
            {
                return await _medicoRepository.ObterMedicoPorId(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao obter médico por ID");
                throw;
            }
        }

        public async Task<Medico> AdicionarMedico(Medico medico)
        {
            try
            {
                return await _medicoRepository.AdicionarMedico(medico);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao adicionar médico");
                throw;
            }
        }

        public async Task<Medico> AtualizarMedico(Medico medico, Guid id)
        {
            try
            {
                return await _medicoRepository.AtualizarMedico(medico, id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao atualizar médico");
                throw;
            }
        }

        public async Task<bool> RemoverMedico(Guid id)
        {
            try
            {
                return await _medicoRepository.RemoverMedico(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao remover médico");
                throw;
            }
        }
    }
}
