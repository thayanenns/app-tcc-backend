using AppTccBackend.Data.Repositories.Interfaces;
using AppTccBackend.Models;
using AppTccBackend.Services.Interfaces;

namespace AppTccBackend.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<List<Usuario>> ObterUsuarios()
        {
            return await _usuarioRepository.ObterUsuarios();
        }

        public async Task<Usuario> ObterUsuarioPorId(Guid id)
        {
            return await _usuarioRepository.ObterUsuarioPorId(id);
        }

        public async Task<Usuario> AdicionarUsuario(Usuario usuario)
        {
            return await _usuarioRepository.AdicionarUsuario(usuario);
        }

        public async Task<Usuario> AtualizarUsuario(Usuario usuario, Guid id)
        {
            return await _usuarioRepository.AtualizarUsuario(usuario, id);
        }

        public async Task<bool> RemoverUsuario(Guid id)
        {
            return await _usuarioRepository.RemoverUsuario(id);
        }
    }
}
