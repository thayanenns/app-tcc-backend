using AppTccBackend.Enum;
using AppTccBackend.Models;

namespace AppTccBackend.Services.Interfaces
{
    public interface ILoginService
    {
        Task<(Usuario usuario, TipoUsuario tipoUsuario)> Autenticar(string email, string senha);

    }
}
