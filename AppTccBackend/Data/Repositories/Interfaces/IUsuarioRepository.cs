using AppTccBackend.Models;

namespace AppTccBackend.Data.Repositories.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<List<Usuario>> ObterUsuarios();
        Task<Usuario> ObterUsuarioPorId(Guid id);

        Task<Usuario> AdicionarUsuario(Usuario usuario);

        Task<Usuario> AtualizarUsuario(Usuario usuario, Guid id);

        Task<bool> RemoverUsuario(Guid id);

        Task<Usuario> ObterUsuarioPorEmail(string email);


    }
}
