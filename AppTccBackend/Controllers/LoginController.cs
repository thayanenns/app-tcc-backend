using AppTccBackend.Data.Repositories;
using AppTccBackend.Data.Repositories.Interfaces;
using AppTccBackend.Enum;
using AppTccBackend.Models;
using AppTccBackend.Models.Dtos;
using AppTccBackend.Services;
using AppTccBackend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace AppTccBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;
        private readonly IUsuarioRepository _usuarioRepository;


        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }
       
        
        [HttpPost]
        public async Task<IActionResult> Autenticar(LoginDto loginDto)
        {
            try
            {
                var (usuario, tipoUsuario) = await _loginService.Autenticar(loginDto.Email, loginDto.Senha);
                return Ok(new { Usuario = usuario, TipoUsuario = tipoUsuario });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Mensagem = ex.Message });
            }
        }
        
    }
}
