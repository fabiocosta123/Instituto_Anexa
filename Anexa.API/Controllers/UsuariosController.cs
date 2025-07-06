using Anexa.Application.UseCases.CriarUsuario;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Anexa.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly CriarUsuarioHandler _handler;

        public UsuariosController(CriarUsuarioHandler handler) 
        {
            _handler = handler;
        }

        [HttpPost]
        public async Task<IActionResult> CriarUsuario([FromBody] CriarUsuarioCommand command)
        {
            var result = await _handler.Handler(command);
            return CreatedAtAction(nameof(CriarUsuario), new { id = result.Id }, result);
        }
    }
}
