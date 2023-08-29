using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AppTccBackend.Models;
using AppTccBackend.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AppTccBackend.Data.Repositories
{
    public class MedicoRepository : IMedicoRepository
    {
        private readonly ApiContexto _context;

        public MedicoRepository(ApiContexto context)
        {
            _context = context;
        }

        public async Task<List<Medico>> ObterMedicos()
        {
            return await _context.Usuarios.OfType<Medico>().ToListAsync();
        }

        public async Task<Medico> ObterMedicoPorId(Guid id)
        {
            return await _context.Usuarios.OfType<Medico>().FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<Medico> AdicionarMedico(Medico medico)
        {
            _context.Usuarios.Add(medico);
            await _context.SaveChangesAsync();
            return medico;
        }

        public async Task<Medico> AtualizarMedico(Medico medico, Guid id)
        {
            var medicoBuscado = await ObterMedicoPorId(id);
            if (medicoBuscado == null)
            {
                throw new Exception("Médico não encontrado no banco");
            }

            // Atualizar as propriedades de Medico aqui
            medicoBuscado.Nome = medico.Nome;
            // Atualize outras propriedades conforme necessário

            _context.Entry(medicoBuscado).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return medicoBuscado;
        }

        public async Task<bool> RemoverMedico(Guid id)
        {
            var medicoBuscado = await ObterMedicoPorId(id);
            if (medicoBuscado == null)
            {
                throw new Exception("Médico não encontrado no banco");
            }

            _context.Usuarios.Remove(medicoBuscado);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
