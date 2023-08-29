using AppTccBackend.Models;

namespace AppTccBackend.Data.Repositories
{
    public class MedicaoRepository
    {
        private readonly ApiContexto _context;

        public MedicaoRepository(ApiContexto context)
        {
            _context = context;
        }

        public IEnumerable<Medicao> ObterMedicao()
        {
            return _context.Medicoes.ToList();
        }

        public Medicao ObterMedicaoPorId(Guid id)
        {
            return _context.Medicoes.FirstOrDefault(p => p.Id == id);
        }

        public void AdicionarMedicao(Medicao medicao)
        {
            _context.Medicoes.Add(medicao);
            _context.SaveChanges();
        }

        public void AtualizarMedicao(Medicao medicao)
        {
            _context.Medicoes.Update(medicao);
            _context.SaveChanges();
        }

        public void RemoverMedicao(Medicao medicao)
        {
            _context.Medicoes.Remove(medicao);
            _context.SaveChanges();
        }
    }
}
