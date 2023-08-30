using AppTccBackend.Data.Repositories.Interfaces;
using AppTccBackend.Models;
using AppTccBackend.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AppTccBackend.Services
{
    public class PacienteService : IPacienteService
    {
        private readonly IPacienteRepository _pacienteRepository;
        private readonly ILogger<PacienteService> _logger;

        public PacienteService(IPacienteRepository pacienteRepository, ILogger<PacienteService> logger)
        {
            _pacienteRepository = pacienteRepository;
            _logger = logger;
        }

        public async Task<List<Paciente>> ObterPacientes()
        {
            try
            {
                return await _pacienteRepository.ObterPacientes();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao obter pacientes");
                throw;
            }
        }

        public async Task<Paciente> ObterPacientePorId(Guid id)
        {
            try
            {
                return await _pacienteRepository.ObterPacientePorId(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao obter paciente por ID");
                throw;
            }
        }

        public async Task<Paciente> AdicionarPaciente(Paciente paciente)
        {
            try
            {
                return await _pacienteRepository.AdicionarPaciente(paciente);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao adicionar paciente");
                throw;
            }
        }

        public async Task<Paciente> AtualizarPaciente(Paciente paciente, Guid id)
        {
            try
            {
                return await _pacienteRepository.AtualizarPaciente(paciente, id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao atualizar paciente");
                throw;
            }
        }

        public async Task<bool> RemoverPaciente(Guid id)
        {
            try
            {
                return await _pacienteRepository.RemoverPaciente(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao remover paciente");
                throw;
            }
        }

        public async Task<List<Paciente>> ObterPacientesDoMedico(Guid medicoId)
        {
            return await _pacienteRepository.ObterPacientesDoMedico(medicoId);
        }

    }
}
