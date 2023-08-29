using AppTccBackend.Models;

namespace AppTccBackend.Services.Interfaces
{
    public interface IUsuarioService
    {
        Task<List<Usuario>> ObterUsuarios();
        Task<Usuario> ObterUsuarioPorId(Guid id);
        Task<Usuario> AdicionarUsuario(Usuario usuario);
        Task<Usuario> AtualizarUsuario(Usuario usuario, Guid id);
        Task<bool> RemoverUsuario(Guid id);
    }
}
