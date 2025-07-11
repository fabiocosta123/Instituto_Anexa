using Anexa.Application.DTOs;
using Anexa.Application.Interfaces;
using Anexa.Application.UseCases.AtualizarCurso;
using Anexa.Application.UseCases.CriarCurso;
using Anexa.Application.UseCases.ObterCursoPorId;
using Anexa.Application.UseCases.RemoverCurso;
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
        private readonly IModuloRepository _moduloRepository;

        public CursosController(ICursoRepository cursoRepository, IUsuarioRepository usuarioRepository, IModuloRepository moduloRepository)
        {
            _cursoRepository = cursoRepository;
            _usuarioRepository = usuarioRepository;
            _moduloRepository = moduloRepository;
        }

        [HttpPost]
        public async Task<ActionResult<CursoDto>> Criar([FromBody] CriarCursoCommand command)
        {
            var handler = new CriarCursoHandler(_cursoRepository, _usuarioRepository ,_moduloRepository);
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

        [HttpPut("{id}")]
        public async Task<ActionResult<CursoDto>> Atualizar(Guid id, [FromBody] AtualizarCursoCommand command)
        {
            var handler = new AtualizarCursoHandler(_cursoRepository);
            var cursoAtualizado = await handler.Handle(id, command);
            if (cursoAtualizado == null)
                return NotFound("Curso não encontrado");
            return Ok(cursoAtualizado);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remover(Guid id)
        {
            var handler = new RemoverCursoHandler(_cursoRepository);
            var sucesso = await handler.Handle(id);

            if (sucesso)
                return NotFound("Curso não encontrado");

            return NoContent();
        }
    }
}