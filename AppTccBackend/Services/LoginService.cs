using AppTccBackend.Data.Repositories.Interfaces;
using AppTccBackend.Enum;
using AppTccBackend.Models;
using AppTccBackend.Services.Interfaces;

namespace AppTccBackend.Services
{
    public class LoginService : ILoginService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public LoginService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<(Usuario usuario, TipoUsuario tipoUsuario)> Autenticar(string email, string senha)
        {
            var usuario = await _usuarioRepository.ObterUsuarioPorEmail(email);

            if (usuario == null)
                throw new Exception("Usuário não encontrado");

            if (!usuario.SenhaValida(senha))
                throw new Exception("Senha incorreta");

            return (usuario, usuario.Tipo);
        }
    }
}

