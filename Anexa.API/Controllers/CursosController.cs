using Anexa.Application.DTOs;
using Anexa.Application.UseCases.CriarCurso;
using Anexa.Application.UseCases.ObterCursoPorId;
using Anexa.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Anexa.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CursosController : ControllerBase
    {
        private readonly ICursoRepository _cursoRepository;
        private readonly IUsuarioRepository _usuarioRepository;

        public CursosController(ICursoRepository cursoRepository, IUsuarioRepository usuarioRepository)
        {
            _cursoRepository = cursoRepository;
            _usuarioRepository = usuarioRepository;
        }

        [HttpPost]
        public async Task<ActionResult<CursoDto>> Criar([FromBody] CriarCursoCommand command)
        {
            var handler = new CriarCursoHandler(_cursoRepository, _usuarioRepository);
            var curso = await handler.Handle(command);

            if (curso == null)
                return BadRequest("Instrutor não encontrado.");

            return CreatedAtAction(nameof(ObterPorId), new { id = curso.Id }, curso);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CursoDto>> ObterPorId(Guid id)
        {
            var handler = new ObterCursoPorIdHandler(_cursoRepository);
            var curso = await handler.Handle(id);

            if (curso == null)
                return NotFound();

            return Ok(curso);
        }
    }
}