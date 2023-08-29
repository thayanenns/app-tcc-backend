using Microsoft.AspNetCore.Mvc;
using AppTccBackend.Models;
using AppTccBackend.Services.Interfaces;

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
    }
}

       
        
        // Outros métodos do controlador relacionados a Usuários
    
    /*  private readonly ApiContexto _context;

      public UsuarioController(ApiContexto context)
      {
          _context = context;
      }

      [HttpGet]
      public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios()
      {
          return await _context.Usuario.ToListAsync();
      }

      [HttpGet("{id}")]
      public async Task<ActionResult<Usuario>> GetUsuario(Guid id)
      {
          var usuario = await _context.Usuario.FindAsync(id);

          if (usuario == null)
          {
              return NotFound();
          }

          return usuario;
      }
      /*[HttpGet("{email}")]
      public Usuario BuscaPorLogin(string email)
      {
         return _context.Usuario.FirstOrDefault(x => x.Email.ToUpper() == email.ToUpper());
      }


      [HttpPost("/login")]
      public IActionResult Login([FromBody] Usuario model)
      {
         // var user = BuscaPorLogin(model.Email);

          if (user == null || user.Senha != model.Senha)
          {
              return Unauthorized(); // Credenciais inválidas
          }

          return Ok(new { Message = "Login bem-sucedido!" });
      }
      
    [HttpPost]
        public async Task<ActionResult<Usuario>> CreateUsuario(Usuario usuario)
        {
            _context.Usuario.Add(usuario);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUsuario), new { id = usuario.Id }, usuario);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUsuario(Guid id, Usuario usuario)
        {
            if (id != usuario.Id)
            {
                return BadRequest();
            }

            _context.Entry(usuario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario(Guid id)
        {
            var usuario = await _context.Usuario.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }

            _context.Usuario.Remove(usuario);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UsuarioExists(Guid id)
        {
            return _context.Usuario.Any(e => e.Id == id);
        }
    }*/
