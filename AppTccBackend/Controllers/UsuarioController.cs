using Microsoft.AspNetCore.Mvc;
using AppTccBackend.Models;
using AppTccBackend.Services.Interfaces;
using AppTccBackend.Enum;
using AppTccBackend.Models.Dtos;

namespace AppTccBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> ObterUsuarioPorId(Guid id)
        {
            var usuario = await _usuarioService.ObterUsuarioPorId(id);
            if (usuario == null)
            {
                return NotFound();
            }

            return usuario;
        }

        [HttpGet]
        public async Task<ActionResult<List<Usuario>>> ObterUsuarios()
        {
            var usuarios = await _usuarioService.ObterUsuarios();
            return usuarios;
        }

        [HttpPost]
        public async Task<ActionResult<Usuario>> AdicionarUsuario(Usuario usuario)
        {
            try
            {
                var novoUsuario = await _usuarioService.AdicionarUsuario(usuario);
                return CreatedAtAction(nameof(ObterUsuarioPorId), new { id = novoUsuario.Id }, novoUsuario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarUsuario(Guid id, Usuario usuario)
        {
            if (id != usuario.Id)
            {
                return BadRequest();
            }

            try
            {
                await _usuarioService.AtualizarUsuario(usuario, id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoverUsuario(Guid id)
        {
            try
            {
                await _usuarioService.RemoverUsuario(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return NoContent();
        }

        [HttpGet("{id}/Detalhes")]
        public async Task<ActionResult<UsuarioDetalhesDto>> ObterDetalhesUsuario(Guid id)
        {
            var usuario = await _usuarioService.ObterUsuarioPorId(id);

            if (usuario == null)
            {
                return NotFound();
            }

            Guid? medicoId = null;
            if (usuario is Medico medico)
            {
                medicoId = medico.Id;
            }

            var usuarioDetalhes = new UsuarioDetalhesDto
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                MedicoId = medicoId
            };

            return Ok(usuarioDetalhes);
        }

    }
}

       
