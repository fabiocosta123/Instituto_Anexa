using Anexa.Application.Queries;
using Anexa.Application.UseCases.AtualizarUsuario;
using Anexa.Application.UseCases.CriarUsuario;
using Anexa.Application.UseCases.RemoverUsuario;
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

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterPorId(Guid id)
        {
            var query = new ObterUsuarioPorIdQuery(id);
            var handler = new ObterUsuarioPorIdHandler(_usuarioRepository);

            var usuario = await handler.Handle(query);

            if (usuario == null)
                return NotFound();

            return Ok(usuario);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(Guid id, [FromBody] AtualizarUsuarioCommand command)
        {
            if (id != command.Id)
                return BadRequest("O ID da URL não corresponde ao ID do corpo da requisição.");

            var handler = new AtualizarUsuarioHandler(_usuarioRepository);
            var sucesso = await handler.Handle(command);

            return sucesso ? NoContent() : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remover(Guid id)
        {
            var handler = new RemoverUsuarioHandler(_usuarioRepository);
            var sucesso = await handler.Handle(id);

            return sucesso ? NoContent() : NotFound();
        }

    }
}

   