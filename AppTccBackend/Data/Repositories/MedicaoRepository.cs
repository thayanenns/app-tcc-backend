using AppTccBackend.Data.Repositories.Interfaces;
using AppTccBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace AppTccBackend.Data.Repositories
{
    public class MedicaoRepository : IMedicaoRepository
    {
        private readonly ApiContexto _context;

        public MedicaoRepository(ApiContexto context)
        {
            _context = context;
        }

        public async Task<List<Medicao>> ObterMedicoes()
        {
            return _context.Medicoes.ToList();
        }

        public async Task<Medicao> ObterMedicaoPorId(Guid id)
        {
            return await _context.Medicoes.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Medicao> AdicionarMedicao(Medicao medicao)
        {
            await _context.Medicoes.AddAsync(medicao);
            await _context.SaveChangesAsync();
            return medicao;
        }

        public async Task<Medicao>AtualizarMedicao(Medicao medicao, Guid id)
        {
            var medicaoBuscado = await ObterMedicaoPorId(id);
            if (medicaoBuscado == null)
            {
                throw new Exception("Medição não encontrado no banco");
            }

            medicaoBuscado.PressaoSistolica = medicao.PressaoSistolica;
            medicaoBuscado.PressaoDiastolica = medicao.PressaoDiastolica;

            _context.Medicoes.Update(medicaoBuscado);
            await _context.SaveChangesAsync();

            return medicaoBuscado;
        }

        public async Task<bool> RemoverMedicao(Guid id)
        {
            var medicaoBuscado = await ObterMedicaoPorId(id);
            if (medicaoBuscado == null)
            {
                throw new Exception("Medição não encontrado no banco");
            }
            _context.Medicoes.Remove(medicaoBuscado);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Medicao>> ObterMedicoesDoPaciente(Guid pacienteId)
        {
            return await _context.Medicoes.Where(p => p.PacienteId == pacienteId).ToListAsync();
        }

    }
}
