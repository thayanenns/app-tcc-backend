using AppTccBackend.Models;
using AppTccBackend.Data.Repositories;
using AppTccBackend.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AppTccBackend.Data.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ApiContexto _context;

        public UsuarioRepository(ApiContexto context)
        {
            _context = context;
        }

        public async Task<List<Usuario>> ObterUsuarios()
        {
            return await _context.Usuarios.ToListAsync();
        }

        public async Task<Usuario> ObterUsuarioPorId(Guid id)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Usuario>  AdicionarUsuario(Usuario usuario)
        {
            await _context.Usuarios.AddAsync(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }

        public async Task<Usuario> AtualizarUsuario(Usuario usuario, Guid id)
        {
            Usuario usuarioBuscado = await ObterUsuarioPorId(id);
            if(usuarioBuscado == null)
            {
                throw new Exception("Usuário não encontrado no banco");
            }
            usuarioBuscado.Nome = usuario.Nome;
            usuarioBuscado.Telefone = usuario.Telefone;

            _context.Usuarios.Update(usuarioBuscado);
           await _context.SaveChangesAsync();

            return usuarioBuscado;
        }

        public async Task<bool> RemoverUsuario(Guid id)
        {
            Usuario usuarioBuscado = await ObterUsuarioPorId(id);
            if (usuarioBuscado == null)
            {
                throw new Exception("Usuário não encontrado no banco");
            }

            _context.Usuarios.Remove(usuarioBuscado);
            await _context.SaveChangesAsync();

            return true;

        }

        public async Task<Usuario> RealizarLogin(string email, string senha)
        {
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == email);

            if (usuario == null || !usuario.SenhaValida(senha))
            {
                throw new Exception("Usuário não cadastrado");
            }

            return usuario;
        }

        public async Task<Usuario> ObterUsuarioPorEmail(string email)
        {
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Email.ToLower() == email.ToLower());

            return usuario;
        }
    }
}
