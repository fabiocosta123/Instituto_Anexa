using Anexa.Application.Queries;
using Anexa.Application.UseCases.CriarUsuario;
using Anexa.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Anexa.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly CriarUsuarioHandler _handler;
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuariosController(CriarUsuarioHandler handler, IUsuarioRepository usuarioRepository)
        {
            _handler = handler;
            _usuarioRepository = usuarioRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CriarUsuario([FromBody] CriarUsuarioCommand command)
        {
            var result = await _handler.Handler(command);
            return CreatedAtAction(nameof(CriarUsuario), new { id = result.Id }, result);
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodos()
        {
            var query = new ObterTodosUsuariosQuery();
            var handler = new ObterTodosUsuariosHandler(_usuarioRepository);

            var usuarios = await handler.Handle(query);
            return Ok(usuarios);
        }

    }
}

   